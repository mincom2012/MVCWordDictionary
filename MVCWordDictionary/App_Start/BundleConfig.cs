﻿using System.Web;
using System.Web.Optimization;

namespace MVCWordDictionary
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax*",
                        "~/Scripts/CustomScripts/CustomValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/fckeditor").Include(
                         "~/Scripts/fckeditor/fckeditor.js"));

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
                      "~/Content/CustomStyleSheet.css"));

            bundles.Add(new StyleBundle("~/Content/themes/jquery-ui").Include(
                "~/Content/themes/base/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/themes/css").Include(
                 "~/Content/themes/base/base.css",
                 "~/Content/themes/ui-lightness/jquery-ui.ui-lightness.css"
                                       ));
        }
    }
}
