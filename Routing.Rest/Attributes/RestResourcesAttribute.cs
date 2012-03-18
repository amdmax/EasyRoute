using System;
using System.Collections.Generic;
using Routing.Rest.Routing;

namespace Routing.Rest.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public class RestResourcesAttribute : RestRoutingAttribute
	{

		private readonly Type _parent;

		public RestResourcesAttribute(Type controllerType, Type parent)
		{
		    _controllerType = controllerType;
			_parent = parent;
		}

		public override int Priority
		{
			get { return 1; }
		}

		public override ICollection<RouteInfo> Process(ControllerTypesList controllerTypesList)
		{
			var collection = new List<RouteInfo>();
			foreach (var ct in controllerTypesList)
			{
				var attribute = (RestResourcesAttribute) ct.Attribute;
				collection.Add(new RouteInfo(){Controller = ct.ControllerType.Name.Replace("_controllerType", string.Empty)});
			}
			return collection;
		}

	    public override string GetRouteUrl()
	    {
	        var controllerName = GetControllerName();
	        return controllerName + "/" + "{action}";
	    }

	    private string GetControllerName()
	    {
	        var controllerSuffix = "Controller";
	        var length = controllerSuffix.Length;
	        var controllerName = ControllerType.Name.Remove(ControllerType.Name.Length - length, length);
	        return controllerName;
	    }

	    public override object GetDefaults()
	    {
	        return new {controller=GetControllerName()};
	    }
	}
}