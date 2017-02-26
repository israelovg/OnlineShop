using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Web.Controllers
{
    public class DataServiceController : ApiController
    {
        private readonly IProductService _ProductService;
        private readonly ICategoryService _CategoryService;
        public DataServiceController(IProductService productService,ICategoryService categoryService)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
        }
        [HttpGet]
        public IEnumerable<ProductReviewView> GetProductReviews(int id)
        {
            return _ProductService.GetProductReviews(id);
        }
        [HttpPost]
        public IEnumerable<ProductReviewView> AddProductReview(ProductReviewView productReviewView)
        {
            if (User.Identity.IsAuthenticated)
            {
                productReviewView.AspNetUserId = User.Identity.GetUserId();
                _ProductService.AddProductReview(productReviewView);
            }
            return _ProductService.GetProductReviews(productReviewView.ProductId);
        }
        [HttpGet]
        public IEnumerable<CategoryView> GetCategories()
        {
            List<CategoryView> categories = new List<CategoryView>();
            categories.Add(new CategoryView { Id = 0,  Name="Everything" });
            categories.AddRange(_CategoryService.GetCategories());
            return categories;
        }
    }
}
