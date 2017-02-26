using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OnlineShop.App_Start
{
    public class BundleConfig
    {
            public static void RegisterBundles(BundleCollection bundles)
            {
            bundles.Add(new ScriptBundle("~/bundles/gridmvc").Include(
                        "~/Scripts/gridmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/gridmvc").Include(
                   "~/Content/Gridmvc.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery-2.1.3.min.js",
                            "~/scripts/jquery-ui-1.10.3.custom/js/jquery-ui-1.10.3.custom.min.js"));

                bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                            "~/Scripts/jquery.validate*"));

                // Use the development version of Modernizr to develop with and learn from. Then, when you're
                // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
                bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

                bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                          "~/scripts/bootstrap.min.js",
                          "~/Scripts/respond.min.js"));
                bundles.Add(new ScriptBundle("~/bundles/general").Include(
                       "~/app/utils.js"));

                bundles.Add(new StyleBundle("~/Content/css").Include(
                            "~/scripts/jquery-ui-1.10.3.custom/css/redmond/jquery-ui-1.10.3.custom.min.css",
                            "~/Content/bootstrap.css",
                            "~/Content/site.css",
                            "~/Content/bootstrap-theme.min.css"
                            ));
            }
        }
}