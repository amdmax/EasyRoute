using System;
using System.Collections.Generic;
using Routing.Web.Attributes;
using Routing.Web.Routing;

namespace Routing.Web.Configuration
{
	public class ControllerTypesList:List<ControllerWithAttr>
	{
		public ControllerTypesList(RestfullRoutingAttribute attribute)
		{
			Guard.ThrowIfNull(attribute, "attribute");
			Attribute = attribute;
		}

		public RestfullRoutingAttribute Attribute { get; protected set; }
	}
}