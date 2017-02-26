using OnlineShop.EF;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Interfaces
{
    public interface IProductService
    {
        ProductView GetProduct(int id);
        IEnumerable<ProductReviewView> GetProductReviews(int id);
        void AddProductReview(ProductReviewView productReviewView);
        IEnumerable<ProductView> GetProducts();
        void UpsertProduct(ProductView Product);
        void RemoveProduct(int id);
        ProductView GetProductById(int id);
    }
}
