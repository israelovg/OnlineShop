using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Service.ModelViews;
using OnlineShop.EF;
using Microsoft.AspNet.Identity;
using System.Web;

namespace OnlineShop.Service.OderTypeStrategy
{
    class AllCart : BaseOrderTypeStrategy, IOrderType
    {
        public OrderView GetOrderReview(int targetId)
        {
            OrderView order = new OrderView { TargetId = targetId, OrderType = Enums.OrderTypeEnum.AllCart,OrderTypeInt=(int)Enums.OrderTypeEnum.AllCart,OrderStatusId=1 };
            if (HttpContext.Current != null)
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                using (var onlineShopContext = new OnlineShopWebEntities())
                {
                    var carts = onlineShopContext.Cart.Where(x => x.AspNetUserId == userId).ToList();
                    order.OrderDetails = carts.Select(x => new OrderDetailView { Product = AutoMapper.Mapper.Map<Product, ProductView>(x.Product), Quantity = x.Quantity }).ToList();
                }
            }
            return order;
        }
        public void CheckoutOrder(OrderView order)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var newOrder = AutoMapper.Mapper.Map<OrderView, Order>(order);
                var carts = onlineShopContext.Cart.Where(x => x.AspNetUserId == order.AspNetUserId);

                foreach (var cart in carts)
                    newOrder.OrderDetails.Add(new OrderDetail { Product = cart.Product, Quantity = cart.Quantity, UnitPrice = cart.Product.Price });

                onlineShopContext.Order.Add(newOrder);
                onlineShopContext.Cart.RemoveRange(carts);
                onlineShopContext.SaveChanges();
            }
        }


    }
}
