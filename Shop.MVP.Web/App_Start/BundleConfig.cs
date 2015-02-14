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
            "~/Scripts/slider.js",
            "~/Scripts/jquery.slider.js",
            "~/Scripts/custom.js"));

      bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Css/jquery.slider.css",
                "~/Css/prettyPhoto.css",
                "~/Css/slider.css",
                "~/Css/style.css",
                "~/Css/delicious/stylesheet.css"
            )); 
    }
  }
}