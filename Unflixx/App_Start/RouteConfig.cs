using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Unflixx
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //below is the attribute routes enabling process
            routes.MapMvcAttributeRoutes();

            //below is a custom route where we can make pages according to our need and can take 3 parameters
            //the custom routes should be above the default routes
            //this is a traditional way of dealing with routes which is no longer efficient

            /*     routes.MapRoute(                                                  
                     "MoviesByReleaseDate",                                        
                     "movies/released/{year}/{month}",
                     new { controller = "Movies", action = "ByReleaseDate"},
                     new { year = @"\d{4}" , month = @"\d{2}" } //this is an argument to constraint input where year = 4digit and month= 2 digit
                     ); 
                     */


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
