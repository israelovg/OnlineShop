using OnlineShop.EF;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineShop.Service.Services
{
    public class ProductService : IProductService
    {
        public ProductView GetProduct(int id)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                return AutoMapper.Mapper.Map<Product, ProductView>(onlineShopContext.Product.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        public IEnumerable<ProductReviewView> GetProductReviews(int id)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                return AutoMapper.Mapper.Map<IEnumerable<ProductReview>, IEnumerable<ProductReviewView>>(onlineShopContext.ProductReview.Where(x => x.ProductId == id));
            }
        }
        public void AddProductReview(ProductReviewView productReviewView)
        {
                var productReview = AutoMapper.Mapper.Map<ProductReviewView, ProductReview>(productReviewView);
                using (var onlineShopContext = new OnlineShopWebEntities())
                {
                    productReview.ReviewDate = DateTime.Now;
                    onlineShopContext.ProductReview.Add(productReview);
                    onlineShopContext.SaveChanges();
                }
           
        }
        public IEnumerable<ProductView> GetProducts()
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                return AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(onlineShopContext.Product);
            }
        }
        public void UpsertProduct(ProductView Product)
        {

            if (Product.Id > 0)
                this.UpdateProduct(Product);
            else
                this.AddProduct(Product);


        }
        public void RemoveProduct(int id)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var Product = onlineShopContext.Product.Find(id);
                if (Product != null)
                {
                    onlineShopContext.Product.Remove(Product);
                    onlineShopContext.SaveChanges();
                }
            }
        }
        public ProductView GetProductById(int id)
        {
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var Product = onlineShopContext.Product.Find(id);
                return AutoMapper.Mapper.Map<Product, ProductView>(Product);
            }
        }
        private void AddProduct(ProductView Product)
        {
            var ProductAdd = AutoMapper.Mapper.Map<ProductView, Product>(Product);
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                onlineShopContext.Product.Add(ProductAdd);
                onlineShopContext.SaveChanges();
            }
        }
        private void UpdateProduct(ProductView Product)
        {
            var ProductUpdate = AutoMapper.Mapper.Map<ProductView, Product>(Product);
            using (var onlineShopContext = new OnlineShopWebEntities())
            {
                var ProductOriginal = onlineShopContext.Product.Find(Product.Id);
                if (Product != null)
                {
                    onlineShopContext.Entry(ProductOriginal).CurrentValues.SetValues(ProductUpdate);
                    onlineShopContext.SaveChanges();
                }
            }
        }
    }
}
