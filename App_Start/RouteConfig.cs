using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // new routing approch now we can define route attribute in controller
            routes.MapMvcAttributeRoutes();

            /*old approch of creating routes and these needs to be arranged from specific to generic
            if default is added above this route definition it will never be called

            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movie", action = "ByReleaseDate"},
                new { year = @"\d{4}", month = @"\d{2}"});*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
