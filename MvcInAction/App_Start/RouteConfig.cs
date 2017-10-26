using System.Web.Mvc;
using System.Web.Routing;

namespace MvcInAction
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // route with constraint
            routes.MapRoute(
                name: "ConstraintRoute",
                url: "constraint/{id}",
                defaults: new { controller = "Constraint", action = "Constraint" },
                constraints: new { id = "[0-9]+" }
            );

            // route with no constraint
            routes.MapRoute(
                name: "NoConstraintRoute",
                url: "constraint/{id}",
                defaults: new { controller = "Constraint", action = "NoConstraint" }
            );

            // default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}