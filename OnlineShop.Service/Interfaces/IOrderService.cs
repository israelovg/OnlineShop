using OnlineShop.Service.Enums;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface IOrderService
    {
        OrderView GetOrder(int targetId, OrderTypeEnum orderTypeEnum);
        void ChechoutOrder(OrderView order);
        IEnumerable<OrderView> GetUserOrders(string userId);
    }
}
