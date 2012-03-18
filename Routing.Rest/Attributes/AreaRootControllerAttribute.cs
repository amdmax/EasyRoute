using System;
using System.Collections.Generic;
using Routing.Rest.Common;
using Routing.Rest.Routing;

namespace Routing.Rest.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class AreaRootControllerAttribute: RestRoutingAttribute
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

	    public override string GetRouteUrl()
	    {
	        throw new NotImplementedException();
	    }

	    public override object GetDefaults()
	    {
	        throw new NotImplementedException();
	    }
	}
}