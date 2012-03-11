using System;
using System.Collections.Generic;
using Routing.Rest.Routing;
using Routing.Web.Attributes;
using Routing.Web.Configuration;

namespace Routing.Rest.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class PostRestMethodAttribute : RestfullRoutingAttribute
	{
		public override int Priority
		{
			get { return 1; }
		}

		public override ICollection<RouteInfo> Process(ControllerTypesList controllerTypesList)
		{
			return null;
		}
	}
}