using System.Web;
using System.Web.Optimization;

namespace GAPv3
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
                      "~/Content/site.css",
                      "~/Content/Table.css"));

            bundles.Add(new StyleBundle("~/Content/fa").Include(
                "~/Content/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/cssAdmin").Include(
                "~/Content/sb-admin/sb-admin.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapAdmin").Include(
                "~/Scripts/umd/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-easing").Include(
                "~/Scripts/jquery-easing/jquery.easing.js"));

            bundles.Add(new ScriptBundle("~/bundles/sb-admin-js").Include(
                "~/Scripts/sb-admin/sb-admin.js"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                "~/Content/Login.css"));

            bundles.Add(new ScriptBundle("~/bundles/chosen-js").Include(
                "~/Content/Chosen/chosen.jquery.js"));

            bundles.Add(new StyleBundle("~/Content/chosen-css").Include(
                "~/Content/Chosen/chosen.css"));

            bundles.Add(new StyleBundle("~/Content/HighCharts-css").Include(
                "~/Content/Highcharts/highcharts.css"));

            bundles.Add(new ScriptBundle("~/bundles/HighCharts-js").Include(
                "~/Scripts/Highcharts/highcharts.js"));

            bundles.Add(new StyleBundle("~/Content/DataTables-css").Include(
                "~/Content/DataTables/css/dataTables.bootstrap4.css"));

            bundles.Add(new ScriptBundle("~/bundles/DataTables-js").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapBox").Include(
                "~/Scripts/bootbox.js"));

            bundles.Add(new StyleBundle("~/Content/toastr-css").Include(
                "~/content/toastr.css"));

            bundles.Add(new ScriptBundle("~/bundles/toastr-js").Include(
                "~/scripts/toastr.js"));

            bundles.Add(new StyleBundle("~/Content/print-css").Include(
                "~/content/print.css"));

        }
    }
}
