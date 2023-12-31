﻿using System.Web;
using System.Web.Optimization;

namespace CapaFichaUsuario
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/complementos").Include(
                       "~/Scripts/scripts.js",
                       "~/Scripts/fontawesome/all.min.js",
                       "~/Scripts/DataTables/jquery.dataTables.js",
                       "~/Scripts/DataTables/dataTables.responsive.js",
                       "~/Scripts/loadingoverlay/loadingoverlay.min.js",
                       "~/Scripts/DataTables/dataTables.buttons.min.js",
                       "~/Scripts/DataTables/buttons.html5.min.js",
                       "~/Scripts/jquery-ui.js",
                       "~/Scripts/sweetalert.min.js"

                       ));


            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/DataTables/css/jquery.dataTables.css",
                     "~/Content/DataTables/css/responsive.dataTables.css",
                      "~/Content/bootstrap.css",
                      "~/Content/jquery-ui.css",
                     "~/Content/sweetalert.css",
            "~/Content/Site.css"));
        }
    }
}
