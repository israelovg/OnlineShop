using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineShop.Service.Enums;

namespace OnlineShop.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _OrderService;
        public OrderController (IOrderService orderService)
        {
            _OrderService = orderService;
        }
        [HttpPost]
        public ActionResult ConfirmOrder(OrderView order)
        {

            if (ModelState.IsValid)
            {
                order.AspNetUserId = User.Identity.GetUserId();
                order.OrderDate = DateTime.Now;
                order.LastFourCardDigits = order.CardNumber.Substring(11, 4);
                _OrderService.ChechoutOrder(order);
                return RedirectToAction("List");
            }
            else
            {
                OrderTypeEnum orderType = (OrderTypeEnum)order.OrderTypeInt;
                order.OrderDetails = _OrderService.GetOrder(order.TargetId, orderType).OrderDetails;
                return View("ConfirmOrder", order);
            }
        }
        public ActionResult OrderProduct(int id)
        {
            return View("ConfirmOrder", _OrderService.GetOrder(id, Service.Enums.OrderTypeEnum.SingleProduct)); 
        }
        public ActionResult OrderCart(int id)
        {
            return View("ConfirmOrder", _OrderService.GetOrder(id, Service.Enums.OrderTypeEnum.SingleCart));
        }
        public ActionResult OrderAllCart()
        {
            return View("ConfirmOrder", _OrderService.GetOrder(-1, Service.Enums.OrderTypeEnum.AllCart));
        }
        public ActionResult List()
        {
            return View(_OrderService.GetUserOrders(User.Identity.GetUserId()));
        }
    }
}