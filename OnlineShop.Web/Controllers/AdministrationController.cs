using OnlineShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class AdministrationController : BaseController
    {
        private readonly ICategoryService _CategoryService;
        public AdministrationController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }
        // GET: Administration
        public ActionResult Categories()
        {
            return View(_CategoryService.GetCategories());
        }
    }
}