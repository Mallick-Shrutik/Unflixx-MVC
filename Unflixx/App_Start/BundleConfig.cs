using System.Web;
using System.Web.Optimization;

namespace Unflixx
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                      "~/scripts/bootbox.js",
                      //datatables is a jquery plugin to add sorting,filtering,pagination
                      "~/scripts/datatables/jquery.datatables.js", 
                       "~/scripts/datatables/datatables.bootstrap.js",
                       "~/scripts/toastr.js",
                       "~/scripts/typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
                       
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/content/toastr.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/content/typeahead.css"));
        }
    }
}
