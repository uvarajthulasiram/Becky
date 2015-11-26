using System.Web;
using System.Web.Optimization;

namespace Becky.Web
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

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/extensions").Include(
                        "~/Scripts/Extensions/jQueryExtensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/extras").Include(
                      "~/Scripts/jquery.form.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/star-rating.js",
                      "~/Scripts/lightslider.js",
                      "~/Scripts/lightgallery.js",
                      "~/Scripts/lg-thumbnail.js",
                      "~/Scripts/lg-fullscreen.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/star-rating.css",
                      "~/Content/lightslider.css",
                      "~/Content/lightgallery.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryuicss").Include(
                      "~/Content/themes/base/all.css"));
        }
    }
}
