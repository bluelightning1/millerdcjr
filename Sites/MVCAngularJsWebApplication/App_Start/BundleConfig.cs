using System.Web;
using System.Web.Optimization;

namespace MVCAngularJsWebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                       "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/css/styles").Include(
                      "~/Content/ui-grid-unstable.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-route.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/uiGrid").Include(
                   "~/Scripts/ui-grid-unstable.js"
                   ));


            bundles.Add(new ScriptBundle("~/bundles/MVCAngularJsWebApplication")
                .IncludeDirectory("~/Scripts/Factories", "*.js")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .Include("~/Scripts/MVCAngularJsWebApplication.js")
                );

            BundleTable.EnableOptimizations = true;
        }
    }
}
