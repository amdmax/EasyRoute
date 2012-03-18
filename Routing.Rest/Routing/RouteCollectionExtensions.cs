using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Routing.Rest.Attributes;

namespace Routing.Rest.Routing
{
    public static class RouteCollectionExtensions
    {
        public static IEnumerable<Type> GetControllerTypes(Assembly assembly, Type controllerBaseType)
        {
            return assembly.GetExportedTypes().Where(controllerBaseType.IsAssignableFrom);
        }

        public static void RegisterRestControllers(this RouteCollection routeCollection, Assembly assembly = null, Type controllerBaseType = null)
        {
            var callingAssembly = assembly ?? Assembly.GetCallingAssembly();
            var controllerType = controllerBaseType ?? typeof(Controller);

            var types = GetControllerTypes(callingAssembly, controllerType);

            foreach (var exportedControllerType in types)
            {
                RegisterControllerFromAttributes(routeCollection, exportedControllerType);
            }
        }

        private static void RegisterControllerFromAttributes(RouteCollection routeCollection, Type exportedControllerType)
        {
            var attributes = exportedControllerType.GetCustomAttributes(typeof (RestResourcesAttribute), true);
            var resource = (RestResourcesAttribute) attributes.FirstOrDefault();
            if (resource == null)
                return;

            routeCollection.MapRoute(null, resource.GetRouteUrl(), resource.GetDefaults());
        }

        public static void Map(this RouteCollection collection, RouteInfo rootRoute)
        {
            foreach (RouteInfo ri in rootRoute.TreeStructureToList())
                collection.MapPageRoute(ri.GetRouteName(), ri.GetRouteUrl(), string.Empty);
        }
    }
}