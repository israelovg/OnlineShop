using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface ICatalogService
    {
        CatalogResult GetCatalog(int pageSize, string search = null, int page = 0, int? category = null);
    }
}
