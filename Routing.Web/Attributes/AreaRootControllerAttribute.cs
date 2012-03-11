using System;
using System.Collections.Generic;
using Routing.Web.Configuration;
using Routing.Web.Routing;

namespace Routing.Web.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class AreaRootControllerAttribute: RestfullRoutingAttribute
	{
		public AreaRootControllerAttribute(string name)
		{
			Guard.ThrowIfNull(name, "name");
			Name = name;
		}
		public string Name { get; set; }
		public override int Priority
		{
			get { return 1; }
		}

		public override ICollection<RouteInfo> Process(ControllerTypesList controllerTypesList)
		{
			var collection = new List<RouteInfo>();
			foreach (var ct in controllerTypesList)
			{
				var attribute = (AreaRootControllerAttribute) ct.Attribute;
				var ri = new RouteInfo(attribute.Name);
				collection.Add(ri);
			}
			return collection;

		}
	}
}