using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
 
    public class CategoryController : BaseController
    {

        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult List()
        {
            return View(_CategoryService.GetCategories());
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Upsert(int id)
        {
            CategoryView category = new CategoryView { Id = -1 };
            if (id > 0)
                category = _CategoryService.GetCategoryById(id);
            return View(category);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Upsert(CategoryView category)
        {
            if (ModelState.IsValid)
            {
                _CategoryService.UpsertCategory(category);
                return RedirectToAction("List");
            }
            else
                return View(category);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Remove(int id)
        {
            _CategoryService.RemoveCategory(id);
            return RedirectToAction("List");
        }
        public ActionResult CategoryMenu()
        {
            return View(_CategoryService.GetCategories());
        }
    }
}