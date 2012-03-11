using System.Collections.Generic;
using Routing.Rest.Attributes;
using Routing.Rest.Common;
using Routing.Web.Configuration;

namespace Routing.Rest
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