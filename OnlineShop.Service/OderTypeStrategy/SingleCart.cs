using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Service.ModelViews;
using OnlineShop.EF;

namespace OnlineShop.Service.OderTypeStrategy
{
    public class SingleCart : BaseOrderTypeStrategy, IOrderType
    {
        public OrderView GetOrderReview(int targetId)
        {
            OrderView order = new OrderView { TargetId = targetId, OrderType = Enums.OrderTypeEnum.SingleProduct, OrderTypeInt = (int)Enums.OrderTypeEnum.SingleCart , OrderStatusId = 1 };
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var cart = onlineShopContext.Cart.Where(x => x.Id == targetId).FirstOrDefault();
                if(cart!=null)
                  order.OrderDetails.Add(new OrderDetailView { Product = AutoMapper.Mapper.Map<Product, ProductView>(cart.Product), Quantity = cart.Quantity });
            }
            return order;
        }

        public void CheckoutOrder(OrderView order)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var newOrder = AutoMapper.Mapper.Map<OrderView, Order>(order);
                var cart = onlineShopContext.Cart.Where(x => x.Id == order.TargetId).FirstOrDefault();
                if (cart != null)
                {
                    newOrder.OrderDetails.Add(new OrderDetail { Product = cart.Product, Quantity = cart.Quantity, UnitPrice = cart.Product.Price });
                    onlineShopContext.Cart.Remove(cart);
                }
                onlineShopContext.Order.Add(newOrder);
                onlineShopContext.SaveChanges();
            }
        }
    }
}
