using System.IO;
using System.Web;
using System.Web.Optimization;

namespace Store
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        "~/Scripts/inputmask/jquery.inputmask.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-1.13.2.min.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/ekimba.css",
                      "~/Content/w3.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/jszip.min.js",
                        "~/Scripts/kendo/kendo.all.min.js",
                        // "~/Scripts/kendo/kendo.timezones.min.js", // uncomment if using the Scheduler
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
            "~/Content/kendo/kendo.common-bootstrap.min.css",
            "~/Content/kendo/kendo.bootstrap.min.css"
            ));
            bundles.Add(new StyleBundle("~/Content/kendo/theme").Include("~/Content/Themes/First.all.css"));

            string culture = "ru-RU";
            try
            {
                File.WriteAllText(Path.Combine(HttpContext.Current.Server.MapPath("~/Scripts"), "culture.js"), "kendo.culture(\"" + culture + "\");");
            }
            catch { };
            bundles.Add(new ScriptBundle("~/bundles/culture").Include(
                        "~/Scripts/kendo/cultures/kendo.culture." + culture + ".min.js",
                        "~/Scripts/kendo/messages/kendo.messages.ru-RU.min.js",
                        "~/Scripts/culture.js"
                        ));
        }
    }
}
