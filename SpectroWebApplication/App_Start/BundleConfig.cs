using System.Web;
using System.Web.Optimization;

namespace SpectroWebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/spectro.js",
                      "~/Scripts/spectro.contents.js",
                      "~/Scripts/spectro.wysiwyg.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/common.css",
                      "~/Content/spectro.css"));
        }
    }
}
