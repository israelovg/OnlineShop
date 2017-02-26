using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Graph;
using OnlineShop.Service.Services;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
                //                x.For<IExample>().Use<Example>();
                x.For<ICatalogService>().Use<CatalogService>();
                x.For<IProductService>().Use<ProductService>();
                x.For<IOrderService>().Use<OrderService>();
                x.For<ICategoryService>().Use<CategoryService>();
            });
            return ObjectFactory.Container;
        }
    }
}
