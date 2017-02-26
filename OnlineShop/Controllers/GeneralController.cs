using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class GeneralController : BaseController
    {
        // GET: General
        public ActionResult Error()
        {
            return View();
        }
    }
}