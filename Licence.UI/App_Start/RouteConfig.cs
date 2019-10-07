using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Licence.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
             

            routes.MapRoute(name: "MainPage", url: "", defaults: new { controller = "Main", action = "MainPage" });

            routes.MapRoute(name: "customer", url: "save-customer", defaults: new { controller = "SmsConfig", action = "AjaxPostCall" });
 
 

          
        }
    }
}
