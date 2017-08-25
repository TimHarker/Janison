using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Janison
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string bundleVersion = MvcApplication.BundleVersion;
            //BundleTable.EnableOptimizations = true;

            // Scipts
            bundles.Add(new ScriptBundle("~/bundles/libraryjs" + bundleVersion).Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-aria.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-ui-router-title.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-messages.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-material.js",
                //"~/Scripts/lodash.js",
                //"~/Scripts/ng-csv.js",
                //"~/Scripts/jquery-{version}.js",
                //"~/Scripts/bootstrap.js",
                //"~/Scripts/ui-bootstrap-custom-2.5.0.js",
                "~/Scripts/ui-bootstrap-custom-tpls-2.5.0.js",
                "~/Scripts/loading-bar.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/appjs" + bundleVersion).IncludeDirectory("~/app", "*.js", true));

            // Styles
            bundles.Add(new StyleBundle("~/bundles/librarycss" + bundleVersion).Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/loading-bar.css"
                ));
            bundles.Add(new StyleBundle("~/bundles/appcss" + bundleVersion).IncludeDirectory("~/app", "*.css", true));
        }
    }
}