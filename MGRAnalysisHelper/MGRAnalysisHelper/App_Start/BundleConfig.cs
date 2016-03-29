using System.Web;
using System.Web.Optimization;

namespace MGRAnalysisHelper
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin.css"));
            bundles.Add(new StyleBundle("~/Content/css-sb").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/metisMenu.min.css",
                "~/Content/css/morris.css",
                "~/Content/css/timeline.css",
                "~/Content/css/sb-admin-2.css"
                ));
            bundles.Add(new ScriptBundle("~/Content/js-sb").Include(
                "~/Content/js/jquery.min.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/metisMenu.min.js",
                "~/Content/js/raphael-min.js",
                "~/Content/js/morris.min.js",
                "~/Content/js/morris-data.js",
                "~/Content/js/sb-admin-2.js"
    ));
        }
    }
}
