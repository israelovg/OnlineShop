using AutoMapper;
using OnlineShop.EF;
using OnlineShop.Service.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service
{
    public  class AutoMapConfig
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg => {
                // cfg.CreateMap<Asset, AssetView>();
                cfg.CreateMap<Product, ProductView>()
                .ForMember(vm => vm.ProductRating, m => m.MapFrom(u => u.ProductReviews != null && u.ProductReviews.Count > 0 ? (Convert.ToInt32(Math.Round(u.ProductReviews.Average(x => x.Rating), 0))) : 0));
                cfg.CreateMap<ProductView, Product>();
                cfg.CreateMap<Cart, CartView>();
                cfg.CreateMap<Category, CategoryView>();
                cfg.CreateMap<CategoryView, Category>();
                cfg.CreateMap<AspNetUsers, AspNetUsersView>();
                cfg.CreateMap<ProductReview, ProductReviewView>()
                 .ForMember(vm => vm.ReviewOwner, m => m.MapFrom(u => u.AspNetUsers.UserName));
                cfg.CreateMap<ProductReviewView, ProductReview>();
                cfg.CreateMap<Cart, CartView>();
                cfg.CreateMap<Order, OrderView>();
                cfg.CreateMap<OrderView, Order>().ForMember(x => x.OrderDetails, opt => opt.Ignore()) ;
                cfg.CreateMap<OrderDetail, OrderDetailView>();
                cfg.CreateMap<OrderStatus, OrderStatusView>();
            });
        }
    }
}
