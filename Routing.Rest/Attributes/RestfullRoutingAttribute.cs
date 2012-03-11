using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Routing.Rest.Routing;
using Routing.Web.Configuration;

namespace Routing.Rest.Attributes
{
	public abstract class RestfullRoutingAttribute : Attribute
	{
		public virtual bool IsRoot()
		{
			return false;
		}

		public abstract int Priority { get; }

		public abstract ICollection<RouteInfo> Process(ControllerTypesList controllerTypesList);

		protected IEnumerable<MethodInfo> GetControllerTypeActionMethods(Type controllerType)
		{
			return controllerType.GetMethods().Where(x => typeof (ActionResult).IsAssignableFrom(x.ReturnType));
		}

		protected IEnumerable<RouteInfo> RegisterActionMethods(ControllerWithAttr record)
		{
			var methods = GetControllerTypeActionMethods(record.ControllerType);
			foreach (var methodInfo in methods)
			{

			}
			return new List<RouteInfo>();
		}
	}
}