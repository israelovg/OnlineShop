using OnlineShop.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.OderTypeStrategy
{
    public static class OrderTypeFactory
    {
        private static readonly Dictionary<OrderTypeEnum, IOrderType> context=new Dictionary<OrderTypeEnum, IOrderType>();
        static OrderTypeFactory()
        {
            context.Add(OrderTypeEnum.SingleProduct, new SingleProduct());
            context.Add(OrderTypeEnum.SingleCart, new SingleCart());
            context.Add(OrderTypeEnum.AllCart, new AllCart());
        }
        public static IOrderType GetOrderTypeStrategy(OrderTypeEnum orderTypeEnum)
        {
            return context[orderTypeEnum];
        }
    }
}
