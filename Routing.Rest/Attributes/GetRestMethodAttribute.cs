using System;
using System.Collections.Generic;
using Routing.Rest.Routing;

namespace Routing.Rest.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class GetRestMethodAttribute: RestRoutingAttribute
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