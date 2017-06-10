using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using OnlineShop.Angular2.App_Start;
using OnlineShop.Service;
using System.Web.Optimization;

namespace OnlineShop.Angular2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            StructuremapMvc.Start();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapConfig.ConfigureAutoMapper();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}