using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.OderTypeStrategy
{
    public interface IOrderType
    {
        OrderView GetOrderReview(int targetId);
        void CheckoutOrder(OrderView order);
    }
}
