using System;
using System.Collections.Generic;
using Routing.Web.Configuration;
using Routing.Web.Routing;

namespace Routing.Web.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public class RestResourcesControllerAttribute : RestfullRoutingAttribute
	{
		private readonly Type _parent;

		public RestResourcesControllerAttribute(Type parent)
		{
			_parent = parent;
		}

		public override int Priority
		{
			get { return 1; }
		}

		public override ICollection<RouteInfo> Process(ControllerTypesList controllerTypesList)
		{
			var collection = new List<RouteInfo>();
			foreach (var ct in controllerTypesList)
			{
				var attribute = (RestResourcesControllerAttribute) ct.Attribute;
				collection.Add(new RouteInfo(){Controller = ct.ControllerType.Name.Replace("Controller", string.Empty)});
			}
			return collection;
		}
	}
}