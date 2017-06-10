using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Angular2.Controllers
{
    public class PartialsController : BaseController
    {
        // GET: Partials
        [AllowAnonymous]
        public ActionResult Header()
        {
            return View();
        }
    }
}