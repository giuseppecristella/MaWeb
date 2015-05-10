using System.Web.Optimization;

namespace Shop.Web.Mvp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/shop").Include(
                  "~/assets/js/bootstrap.min.js",
                  "~/assets/js/jasny-bootstrap.min.js",
                  "~/assets/js/bootstrap-hover-dropdown.min.js",
                  "~/assets/js/wow.min.js",
                  "~/assets/js/jquery-ui.min.js",
                  "~/assets/js/echo.min.js",
                  "~/assets/js/lightbox.min.js",
                  "~/assets/js/jquery.easing-1.3.min.js",
                  "~/assets/js/owl.carousel.min.js",
                  "~/assets/js/jquery.customSelect.min.js",
                  "~/assets/js/jquery.bxslider.min.js",
                  "~/assets/js/jquery.isotope.min.js",
                  "~/assets/js/pace.min.js",
                  "~/assets/js/odometer.min.js",
                  "~/assets/js/scripts.js"));
        }
    }
}