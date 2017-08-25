using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Diagnostics;
using System.Configuration;
using System.Web.Optimization;
using System.Data.Entity;
using Newtonsoft.Json.Serialization;

namespace Janison
{
    public class MvcApplication : HttpApplication
    {
        public static FileVersionInfo VersionInfo { get; private set; }
        public static string StyleTagFormat { get; private set; }
        public static string ScriptTagFormat { get; private set; }
        public static string BundleVersion { get; private set; }

        protected void Application_Start()
        {
            VersionInfo = FileVersionInfo.GetVersionInfo(typeof(MvcApplication).Assembly.Location);
            BundleVersion = ConfigurationManager.AppSettings["BundleVersion"];
            string environment = ConfigurationManager.AppSettings["Environment"];

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            //HttpConfiguration config = GlobalConfiguration.Configuration;
            //((DefaultContractResolver)config.Formatters.JsonFormatter.SerializerSettings.ContractResolver).IgnoreSerializableAttribute = true;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            if (!BundleTable.EnableOptimizations && !string.Equals(environment, "LOCAL"))
            {
                //when in debug (ie, bundling just lists all files) add a version tothe link to avoid cached code issues
                string devBundleCacheBusting = string.Format("?v={0}", DateTime.Now.Ticks);
                ScriptTagFormat = "<script src=\"{{0}}{devBundleCacheBusting}\"></script>";
                StyleTagFormat = "<link rel=\"stylesheet\" href=\"{{0}}{devBundleCacheBusting}\" />";
            }
            else
            {
                ScriptTagFormat = "<script src=\"{0}\"></script>";
                StyleTagFormat = "<link rel=\"stylesheet\" href=\"{0}\" />";
            }
        }
    }
}