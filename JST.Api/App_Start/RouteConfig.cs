using System.Web.Mvc;
using System.Web.Routing;

namespace JST.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute("Default", "index.html");
        }
    }
}
