using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace OnlineShop.Angular2.ApiControllers
{
    public class DataServiceController : ApiController
    {
        private readonly ICatalogService _CatalogService;
        private readonly ICategoryService _CategoryService;
        private readonly IProductService _ProductService;
        private readonly ICartService _CartService;
        private readonly IOrderService _OrderService;
        public DataServiceController(ICatalogService catalogService, ICategoryService categoryService
            , IProductService productService, ICartService cartService
            ,IOrderService orderService)
        {
            _CatalogService = catalogService;
            _CategoryService = categoryService;
            _ProductService = productService;
            _CartService = cartService;
            _OrderService = orderService;
        }
        [HttpGet]
        public CatalogResult GetCatalog(string search = null, int page = 0, int? category = null)
        {
            if (search != null)
                search = HttpUtility.UrlDecode(search);
            return _CatalogService.GetCatalog(8, search, page, category);
        }
        [HttpGet]
        public IEnumerable<CategoryView> GetCategories() {
            return _CategoryService.GetCategories();
        }
        [HttpGet]
        public bool IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
                return true;
            else
                return false;
        }
        [HttpGet]
        public ProductView GetProduct(int id)
        {
            return _ProductService.GetProduct(id);
        }
        [Authorize]
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
        [Authorize]
        [HttpGet]
        public void AddToCart(int id)
        {
            _CartService.AddToCart(id, User.Identity.GetUserId());
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<CartView> GetUserCart()
        {
            return _CartService.GetUserCart(User.Identity.GetUserId());
        }
        [Authorize]
        [HttpPost]
        public async Task<int> RemoveFromCart(CartView cart)
        {
          return  await _CartService.RemoveFromCart(cart.ProductId);
        }
        [Authorize]
        [HttpGet]
        public OrderView OrderProduct(int id)
        {
            return _OrderService.GetOrder(id, Service.Enums.OrderTypeEnum.SingleProduct);
        }
        [Authorize]
        [HttpGet]
        public OrderView OrderCart(int id)
        {
            return _OrderService.GetOrder(id, Service.Enums.OrderTypeEnum.SingleCart);
        }
        [Authorize]
        [HttpGet]
        public OrderView OrderAllCart()
        {
            return _OrderService.GetOrder(-1, Service.Enums.OrderTypeEnum.AllCart);
        }
    }
}
