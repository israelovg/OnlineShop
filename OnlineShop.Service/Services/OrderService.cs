using OnlineShop.EF;
using OnlineShop.Service.Enums;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using OnlineShop.Service.OderTypeStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Services
{
    public class OrderService:IOrderService
    {
        public OrderView GetOrder(int targetId, OrderTypeEnum orderType)
        {
            var orderTypeStrategy = OrderTypeFactory.GetOrderTypeStrategy(orderType);
            var order= orderTypeStrategy.GetOrderReview(targetId);
            order.Total = order.OrderDetails.Sum(x => x.Product.Price * x.Quantity);
            return order;
        }
        public void ChechoutOrder(OrderView order)
        {
            var orderTypeStrategy = OrderTypeFactory.GetOrderTypeStrategy((OrderTypeEnum)order.OrderTypeInt);
            orderTypeStrategy.CheckoutOrder(order);
        }
        public IEnumerable<OrderView> GetUserOrders(string userId)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                return AutoMapper.Mapper.Map< IEnumerable<Order>, IEnumerable<OrderView>>(onlineShopContext.Order.Where(x=>x.AspNetUserId==userId));
            }
        }
    }
}
