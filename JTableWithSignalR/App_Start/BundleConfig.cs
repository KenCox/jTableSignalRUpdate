using System.Web;
using System.Web.Optimization;

namespace JTableWithSignalR
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
                       "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jTable").Include(
                        "~/Scripts/jtable/jquery.jtable.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                       "~/Scripts/jquery.signalR-2.2.0.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                      
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jQueryUI").Include(
                      "~/Content/themes/metroblue/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/jTableUI").Include(
                      "~/Scripts/jtable/themes/metro/blue/jtable.css"));

           
        }
    }
}
