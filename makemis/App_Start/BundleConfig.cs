﻿using System.Web;
using System.Web.Optimization;

namespace makemis {
    public class BundleConfig {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      , "~/Scripts/respond.js"
                      , "~/Scripts/scrollreveal.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/site.js"
                      , "~/Scripts/dashboard.js"
                      , "~/Scripts/resizableText.js"
                      , "~/Scripts/abbreviationTech.js"));

            bundles.Add(new ScriptBundle("~/bundles/auth").Include(
                      "~/Scripts/login.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css"
                      , "~/Content/site.css"
                      , "~/Content/snackbar.css"
                      , "~/Content/resizableText.css"));
        }
    }
}
