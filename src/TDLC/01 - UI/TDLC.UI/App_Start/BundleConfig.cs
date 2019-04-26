using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace TDLC.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            /*
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
                        */



            // Adicionando Validação, e Globalização
            // Utilizando ordenação manual
            var valBundle = new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/globalize.js",
                "~/Scripts/globalize/number.js",
                "~/Scripts/globalize/date.js",
                "~/Scripts/jquery.validate.globalize.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                );


            valBundle.Orderer = new AsIsBundleOrderer();

            bundles.Add(valBundle);














            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Scripts/jquery.datatables/datatables.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/admincss").Include(
          "~/Content/css/custom.min.css",
          "~/Scripts/jquery.datatables/datatables.css",
          "~/Content/site.css"));





            //Datatables
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/jquery.datatables/datatables.js"
               //"~/Scripts/jquery.datatables/moment.min.js",
               //"~/Scripts/jquery.datatables/moment-with-locales.min.js", 
               //"~/Scripts/jquery.datatables/datetime-moment.js"
                ));



        }
    }





    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }





}
