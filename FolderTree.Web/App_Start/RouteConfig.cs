using System.Web.Mvc;
using System.Web.Routing;
using FolderTree.Core.Configurators;

namespace FolderTree.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            var routeCollectionDic = RouteConfigurator.RouteConfigCollection;

            foreach (var k in routeCollectionDic.Keys)
            {
                routes.Add(k, routeCollectionDic[k]);
            }
        }
    }
}
