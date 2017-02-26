using OnlineShop.EF;
using OnlineShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OnlineShop.Service.ModelViews;
using System.Data.Entity;

namespace OnlineShop.Service.Services
{
    public class CartService : ICartService
    {
        public void AddToCart(int id, string userId)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                Cart cart = onlineShopContext.Cart.Where(x => x.AspNetUserId == userId && x.ProductId == id).FirstOrDefault();
                if (cart == null)
                {
                    cart = new Cart { AspNetUserId = userId, ProductId = id, Quantity = 1, DateCreated = DateTime.Now };
                    onlineShopContext.Cart.Add(cart);
                }
                else
                    cart.Quantity++;

                onlineShopContext.SaveChanges();
            }
        }
        public async Task RemoveFromCart(int id)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                Cart cart = onlineShopContext.Cart.Where(x => x.ProductId == id).FirstOrDefault();
                if (cart != null)
                {
                    onlineShopContext.Cart.Remove(cart);
                    await onlineShopContext.SaveChangesAsync();
                }
            }
        }
        public async Task RemoveAllCart(string userId)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var carts = onlineShopContext.Cart.Where(x => x.AspNetUserId == userId);
                onlineShopContext.Cart.RemoveRange(carts);
                await onlineShopContext.SaveChangesAsync();
            }
        }
        public IEnumerable<CartView> GetCartProduct(string userId)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var carts = onlineShopContext.Cart.Include(x => x.Product.Category).Where(x => x.AspNetUserId == userId);
                return AutoMapper.Mapper.Map<IEnumerable<Cart>, IEnumerable<CartView>>(carts);
            }
        }
    }
}
