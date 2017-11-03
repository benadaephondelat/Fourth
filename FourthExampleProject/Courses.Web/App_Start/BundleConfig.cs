namespace Courses.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                   .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                   .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                   .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                   .Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/customersGridModule")
                   .Include("~/Scripts/Custom/customersGridModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/mvcGrid")
                   .Include("~/Scripts/jquery-2.2.4.js")
                   .Include("~/Scripts/MvcGrid/mvc-grid.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                   .Include("~/Content/bootstrap.css", "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/mvc-grid-css")
                   .Include("~/Content/MvcGrid/mvc-grid.css"));
        }
    }
}