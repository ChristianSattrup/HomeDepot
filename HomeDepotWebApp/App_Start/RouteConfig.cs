using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeDepotWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "Login", action = "Login"}
            );
            routes.MapRoute(
                name: "booking",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Booking", action = "ViewBooking", id = UrlParameter.Optional }
            );
        }
    }
}
