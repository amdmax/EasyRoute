using System;
using System.Collections.Generic;
using Routing.Rest.Routing;
using Routing.Web.Configuration;

namespace Routing.Rest.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class PostRestMethodAttribute : RestRoutingAttribute
	{
		public override int Priority
		{
			get { return 1; }
		}

		public override ICollection<RouteInfo> Process(ControllerTypesList controllerTypesList)
		{
			return null;
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