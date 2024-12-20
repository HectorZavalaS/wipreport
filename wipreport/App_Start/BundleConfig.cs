﻿using System.Web;
using System.Web.Optimization;

namespace wipreport
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/nav.js",
                      "~/Scripts/functions.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap4.js",
                      "~/Scripts/DataTables/dataTables.buttons.js",
                      "~/Scripts/jszip.min.js",
                      "~/Scripts/pdfmake/pdfmake.min.js",
                      "~/Scripts/pdfmake/vfs_fonts.js",
                      "~/Scripts/DataTables/buttons.flash.js",
                      "~/Scripts/DataTables/buttons.html5.js",
                      "~/Scripts/DataTables/buttons.print.js",
                      "~/Scripts/DataTables/dataTables.fixedHeader.min.js",
                      "~/Scripts/DataTables/dataTables.responsive.min.js",
                      "~/Scripts/DataTables/responsive.bootstrap.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/loader.css",
                      "~/Content/fontawesome-all.min.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/DataTables/css/fixedHeader.bootstrap.min.css.css",
                      "~/Content/DataTables/css/responsive.bootstrap.min.css.css"
                      ));
        }
    }
}



