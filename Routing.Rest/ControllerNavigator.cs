using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Routing.Rest.Attributes;
using Routing.Rest.Routing;
using Routing.Web.Attributes;
using Routing.Web.Configuration;

namespace Routing.Rest
{
    // TODO: move this to standalone assembly
	public class ControllerNavigator
	{
		#region Transform Controllers to RI
		public static RouteInfo TransformControllersToRouteInfo(IEnumerable<Type> types, Type controllerType, string namespaceName=null)
		{
			var lookup = GetOrderedAttributes(types, controllerType, namespaceName);
			// root route
			var routeInfo = new RouteInfo();
			foreach (var keyValuePair in lookup)
			{
				var list = keyValuePair.Value;
				routeInfo.Update(list.Attribute.Process(list));
			}

			return routeInfo;
		}

		public static RouteInfo TransformControllersToRouteInfo(Assembly assembly, Type controllerType, string namespaceName = null)
		{
			return TransformControllersToRouteInfo(assembly.GetTypes(), controllerType, namespaceName);
		}

		#endregion

		private static IEnumerable<KeyValuePair<Type, ControllerTypesList>> GetOrderedAttributes(IEnumerable<Type> types, Type controllerType, string namespaceName=null)
		{
			return GetAttributesLookup(types, namespaceName, controllerType).OrderBy(x => x.Value.Attribute.Priority);
		}

		private static IDictionary<Type, ControllerTypesList> GetAttributesLookup(IEnumerable<Type> types, string namespaceName, Type controllerType)
		{
			var dictionary = new Dictionary<Type, ControllerTypesList>();

			var controllers = types.Where(controllerType.IsAssignableFrom);
			if (!string.IsNullOrEmpty(namespaceName))
				controllers = controllers.Where(x => x.Namespace == namespaceName);

			// O(n^2)
			foreach (var controller in controllers)
			{
				foreach (RestfullRoutingAttribute controllerCustomAttribute in controller.GetCustomAttributes(typeof (RestfullRoutingAttribute), false))
				{
					var key = controllerCustomAttribute.GetType();
					var value = new ControllerWithAttr(controllerCustomAttribute, controller);

					if (!dictionary.ContainsKey(key))
						dictionary.Add(key, new ControllerTypesList(controllerCustomAttribute) {value});
					else
					{
						dictionary[key].Add(value);
					}
				}
			}
			return dictionary;
		}

		private static IDictionary<Type, ControllerTypesList> GetAttributesLookup(Assembly assembly, string namespaceName, Type controllerType)
		{
			return GetAttributesLookup(assembly.GetTypes(), namespaceName, controllerType);
		}


	}
}