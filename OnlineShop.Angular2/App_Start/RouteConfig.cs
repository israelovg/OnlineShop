using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Angular2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "products",
             url: "products/{*.}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
              name: "product",
              url: "product/{*.}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "addToCart",
             url: "addToCart/{*.}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "cart",
             url: "cart/{*.}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
            name: "confirmOrder",
            url: "confirmOrder/{*.}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
