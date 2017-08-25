using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Janison
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //To enable wildcard route mapping the cshtml files supporting the angular ap, enable routing on existing files, but exclude flat file types
            routes.IgnoreRoute("{*staticfile}", new { staticfile = @".*\.(css|js|html|gif|jpg|eot|svg|ttf|woff|woff2|otf|png|map)(/.*)?" });
            routes.RouteExistingFiles = true;

            routes.MapRoute("app", "app/views/{*viewName}", new { controller = "App", app = "app", action = "GetView" });

            routes.MapRoute("Default", "{*anything}", new { controller = "App", app = "app", action = "GetAppLayout", id = UrlParameter.Optional });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
