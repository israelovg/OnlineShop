using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ModelViews;

namespace OnlineShop.Web.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly ICatalogService _CatalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _CatalogService = catalogService;
        }
        // GET: Catalog
        public ActionResult Index(string search = null, int page = 0, int? category = null)
        {
            if (search != null)
                search = Server.UrlDecode(search);
            return View(_CatalogService.GetCatalog(8,search, page, category));
        }
        public ActionResult LoadMore(string search = null, int page = 0, int? category = null)
        {
            if (search != null)
                search = Server.UrlDecode(search);
            var results = _CatalogService.GetCatalog(8,search, page, category);
            return View(results);
        }
    }
}