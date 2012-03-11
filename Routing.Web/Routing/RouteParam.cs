using System.Web.Routing;

namespace Routing.Web.Routing
{
    public class RouteParam
    {
        public string ParamName { get; set; }
        public IRouteConstraint Constraint { get; set; }
    }
}