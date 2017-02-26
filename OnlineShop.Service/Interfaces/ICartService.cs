using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface ICartService
    {
        void AddToCart(int id, string userId);
        Task RemoveFromCart(int id);
        IEnumerable<CartView> GetCartProduct(string userId);
        Task RemoveAllCart(string userId);
    }
}
