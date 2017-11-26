using System.Collections.Generic;
using System.Linq;
using FolderTree.DAL.Provider;
using System.Web.Mvc;
using System.Web.Routing;

namespace FolderTree.Core.Configurators
{
    public class RouteConfigurator
    {
        private static Dictionary<string, Route> _routes = new Dictionary<string, Route>();

        private const string _controller = "controller";
        private const string _action = "action";
        private const string _id = "id";

        public static string DefaultController { get; set; } = "Home";
        public static string DefaultAction { get; set; } = "Index";
        public static Dictionary<string,Route> RouteConfigCollection => ComposeRoutes();

        private static Dictionary<string, Route> ComposeRoutes()
        {
            using (var context = new RepositoryProvider())
            {
                var routeEntities = context.TreeNodeRepository.GetEntities().Select(r => new
                    {
                        url = r.Url,
                        id = r.Id,
                        name = r.Name
                    })
                    .ToList();

                foreach (var route in routeEntities)
                {
                    _routes.Add(route.name,new Route(route.url, new RouteValueDictionary()
                        {
                            {_controller, DefaultController},
                            {_action, DefaultAction},
                            {_id, route.id}
                        },
                        new MvcRouteHandler()));
                }

            }

            return _routes;
        }
    }
}