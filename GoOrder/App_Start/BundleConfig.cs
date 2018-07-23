using System.Web;
using System.Web.Optimization;

namespace GoOrder
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/dataTables.bootstrap.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/orderCss").Include(

                      "~/Content/bootstrap.css",
                      "~/Content/icomoon.css",
                      "~/Content/flag-icon.min.css",
                      "~/Content/pace.css",
                      "~/Content/bootstrap-extended.css",
                      "~/Content/app.css",
                      "~/Content/colors.css",
                      "~/Content/vertical-menu.css",
                      "~/Content/vertical-overlay-menu.css",
                      "~/Content/invoice.css",
                      "~/Content/style.css",
                      "~/Content/dataTables.bootstrap.min.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/orderJQuery").Include(
                    "~/Scripts/jquery.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/orderJs").Include(                       
                       "~/Scripts/tether.min.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/perfect-scrollbar.jquery.min.js",
                       "~/Scripts/unison.min.js",
                       "~/Scripts/blockUI.min.js",
                       "~/Scripts/jquery.matchHeight-min.js",
                       "~/Scripts/screenfull.min.js",
                       "~/Scripts/pace.min.js",
                       "~/Scripts/app.js",
                       "~/Scripts/app-menu.js"                    
                      
                ));
        }
    }
}
