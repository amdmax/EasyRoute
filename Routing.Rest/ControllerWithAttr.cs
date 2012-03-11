using System;
using Routing.Rest.Attributes;
using Routing.Web.Attributes;

namespace Routing.Web.Configuration
{
	public class ControllerWithAttr
	{
		public ControllerWithAttr(RestfullRoutingAttribute controllerCustomAttribute, Type controller)
		{
			Attribute = controllerCustomAttribute;
			ControllerType = controller;
		}

		public RestfullRoutingAttribute Attribute { get; protected set; }
		public Type ControllerType { get; protected set; }
	}
}