using System.Web.Routing;

namespace Routing.Rest.Routing
{
    public static class RouteCollectionExtensions
    {
        public static void Map(this RouteCollection collection, RouteInfo rootRoute)
        {
            foreach (RouteInfo ri in rootRoute.TreeStructureToList())
                collection.MapPageRoute(ri.GetRouteName(), ri.GetRouteUrl(), string.Empty);
        }
    }
}