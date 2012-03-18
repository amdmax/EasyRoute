using System;
using Routing.Rest.Attributes;

namespace Routing.Web.Configuration
{
	public class ControllerWithAttr
	{
		public ControllerWithAttr(RestRoutingAttribute controllerCustomAttribute, Type controller)
		{
			Attribute = controllerCustomAttribute;
			ControllerType = controller;
		}

		public RestRoutingAttribute Attribute { get; protected set; }
		public Type ControllerType { get; protected set; }
	}
}