using System;
using System.Collections.Generic;
using Routing.Rest;
using Routing.Rest.Attributes;
using Routing.Rest.Routing;
using Routing.Web.Configuration;

namespace Routing.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class GetRestMethodAttribute: RestfullRoutingAttribute
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