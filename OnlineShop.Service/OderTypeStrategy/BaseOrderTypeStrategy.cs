using OnlineShop.Service.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.OderTypeStrategy
{
    public abstract class BaseOrderTypeStrategy
    {
        protected readonly ICartService _CartService;
        public BaseOrderTypeStrategy()
        {
            _CartService = ObjectFactory.GetInstance<ICartService>();
        }
    }
}
