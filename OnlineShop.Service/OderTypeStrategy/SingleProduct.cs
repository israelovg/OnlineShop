using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Service.ModelViews;
using OnlineShop.EF;

namespace OnlineShop.Service.OderTypeStrategy
{
    public class SingleProduct : BaseOrderTypeStrategy, IOrderType
    {
        public OrderView GetOrderReview(int targetId)
        {
            OrderView order = new OrderView { TargetId = targetId, OrderType= Enums.OrderTypeEnum.SingleProduct, OrderTypeInt = (int)Enums.OrderTypeEnum.SingleProduct, OrderStatusId = 1 };
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var product= AutoMapper.Mapper.Map<Product, ProductView>(onlineShopContext.Product.Where(x => x.Id == targetId).FirstOrDefault());
                order.OrderDetails.Add(new OrderDetailView { Product = product, Quantity = 1 });
            }
            return order;
        }

        public void CheckoutOrder(OrderView order)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var newOrder = AutoMapper.Mapper.Map<OrderView, Order>(order);
                var product = onlineShopContext.Product.Where(x => x.Id == order.TargetId).FirstOrDefault();
                 newOrder.OrderDetails.Add(new OrderDetail { Product = product, Quantity = 1, UnitPrice=product.Price });
                onlineShopContext.Order.Add(newOrder);
                onlineShopContext.SaveChanges();
            }
        }
    }
}
