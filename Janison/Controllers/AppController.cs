using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Janison.Controllers
{
    using System.Web.Mvc;

    public class AppController : Controller
    {
        [HttpGet]
        public ActionResult GetView(string app, string viewName)
        {
            return this.View($"~/{app}/views/{viewName}");
        }

        public ActionResult GetAppLayout(string app)
        {
            return this.View($"~/{app}/views/layout/layout.cshtml");
        }
    }
}