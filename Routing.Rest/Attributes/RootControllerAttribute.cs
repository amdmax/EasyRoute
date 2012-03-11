using System;
using System.Collections.Generic;
using System.Linq;
using Routing.Rest;
using Routing.Rest.Attributes;
using Routing.Rest.Common;
using Routing.Rest.Routing;
using Routing.Web.Configuration;

namespace Routing.Web.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class RootControllerAttribute : RestfullRoutingAttribute
	{
		public override bool IsRoot()
		{
			return true;
		}

		public override int Priority
		{
			get { return 0; }
		}

		public override ICollection<RouteInfo> Process(ControllerTypesList controllerTypesList)
		{
			Guard.AssertExpression(() => controllerTypesList.Count() == 1);
			var collection = new List<RouteInfo>(controllerTypesList.Count);
			foreach (var record in controllerTypesList)
			{
				RegisterActionMethods(record);
			}

			return collection;
		}
	}
}