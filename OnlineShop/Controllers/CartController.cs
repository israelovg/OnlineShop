using OnlineShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineShop.Service.ModelViews;
using System.Threading.Tasks;

namespace OnlineShop.Web.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService _CartService;
        public CartController(ICartService cartService)
        {
            _CartService = cartService;
        }
        // GET: Cart
        public ActionResult Index()
        {
                return View(_CartService.GetCartProduct(User.Identity.GetUserId()));
        }
        public ActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> RemoveFromCart(int id)
        {
            await _CartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}