using OnlineShop.EF;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Services
{
    public class CatalogService: ICatalogService
    {
        public IEnumerable<ProductView> GetCatalog(int pageSize,string search=null,int page = 0, int? category = null)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var products = onlineShopContext.Product.Where(x => (category == null || x.CategoryId == category)&&(search==null || x.Name.Contains(search))).OrderBy(x=>x.Id).Skip(pageSize * page).Take(pageSize);
                return AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(products);
            }
        }
    }
}
