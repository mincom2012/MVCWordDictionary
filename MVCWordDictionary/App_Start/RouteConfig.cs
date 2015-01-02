using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCWordDictionary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Admin Controller
            routes.MapRoute(
                name: "Amdin Controller",
                url: "admin/{action}",
                defaults: new { controller = "Manager", action = "Index"}
            );

            //tin-tuc/
            routes.MapRoute(
                name: "News",
                url: "tin-tuc/{action}/{id}",
                defaults: new { controller = "News", action = "Index" , id = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
