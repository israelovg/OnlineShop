using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.ModelViews
{
    public class CartView
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual ProductView Product { get; set; }
    }
}
