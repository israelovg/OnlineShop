using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.ModelViews
{
    public class CatalogResult
    {
        public IEnumerable<ProductView> Products { get; set; }
        public int MoreResults { get; set; }
        public CatalogResult()
        {
            Products = Enumerable.Empty<ProductView>();
        }
    }
}
