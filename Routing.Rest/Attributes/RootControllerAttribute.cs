using System;
using System.Collections.Generic;
using System.Linq;
using Routing.Rest.Common;
using Routing.Rest.Routing;

namespace Routing.Rest.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class RootControllerAttribute : RestRoutingAttribute
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