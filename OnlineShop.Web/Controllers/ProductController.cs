using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _ProductService;
        private readonly ICategoryService _CategoryService;
        private const string  uploadDir = "images/productImg";
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
        }
        // GET: Product
        public ActionResult Index(int id)
        {
            return View(_ProductService.GetProduct(id));
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult List()
        {
            return View(_ProductService.GetProducts());
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Upsert(int id)
        {
            ProductView product = new ProductView { Id = -1 };
            if (id > 0)
                product = _ProductService.GetProductById(id);

            product.CategorySelectItems = _CategoryService.GetCategories().Select(x =>
                         new SelectListItem
                         {
                             Value = x.Id.ToString(),
                             Text = x.Name,
                             Selected = product.CategoryId == x.Id
                         });
            return View(product);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Upsert(ProductView product)
        {
            var validImageTypes = new string[]
               {
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
               };

            if (product.Id == -1 && (product.ImageUpload == null || product.ImageUpload.ContentLength == 0))
            {
                ModelState.AddModelError("ImageUpload", "Product image required");
            }
            else if (product.ImageUpload!=null && !validImageTypes.Contains(product.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }
            if (ModelState.IsValid)
            {
                if (product.ImageUpload != null)
                {
                    SaveImage(product.ImageUpload);
                    product.ProductImagePath = uploadDir + "/" + product.ImageUpload.FileName;
                }
                _ProductService.UpsertProduct(product);
                return RedirectToAction("List");
            }
            else
            {
                product.CategorySelectItems = _CategoryService.GetCategories().Select(x =>
                       new SelectListItem
                       {
                           Value = x.Id.ToString(),
                           Text = x.Name,
                           Selected = product.CategoryId == x.Id
                       });
                return View(product);
            }
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Remove(int id)
        {
            _ProductService.RemoveProduct(id);
            return RedirectToAction("List");
        }
        private void SaveImage(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var imagePath = Path.Combine(Server.MapPath("~/"+uploadDir), file.FileName);
                    var imageUrl = Path.Combine("~/"+uploadDir, file.FileName);
                    file.SaveAs(imagePath);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}