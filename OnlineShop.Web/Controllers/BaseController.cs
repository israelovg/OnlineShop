using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.CurrentController = this.RouteData.Values["controller"].ToString();
            base.OnActionExecuting(filterContext);
            if (!User.Identity.IsAuthenticated && new string[] { "order", "cart"}.Any(x=> this.RouteData.Values["controller"].ToString().Equals(x, StringComparison.InvariantCultureIgnoreCase)))
                filterContext.HttpContext.Response.Redirect(Url.Action("login","account",new { returnUrl = filterContext.HttpContext.Request.Url.AbsoluteUri }));
            
        }
    }
}