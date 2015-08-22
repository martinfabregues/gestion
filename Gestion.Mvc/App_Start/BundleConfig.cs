using System.Web;
using System.Web.Optimization;

namespace Gestion.Mvc
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, consulte http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-theme.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new StyleBundle("~/Content/select2css").Include(
                        "~/Content/select2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/select2js").Include(
                        "~/Scripts/select2.min.js"));
        }
    }
}
