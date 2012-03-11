using System;
using System.Collections.Generic;

namespace Routing.Rest.Routing
{

    [Serializable]
    public class RouteInfo
    {
        #region fields

        private readonly string _area;
        public string Controller { get; set; }
        public string Action { get; set; }

        public ICollection<RouteInfo> Children { get; protected set; }

        public RouteInfo Parent { get; protected set; }

        public ICollection<RouteParam> RoutingParams { get; set; }
        #endregion

        public RouteInfo()
        {
            Children = new List<RouteInfo>();
        	_area = string.Empty;
        }

        public RouteInfo(RouteInfo parent) : this()
        {
            Parent = parent;
        }

        public RouteInfo(string area)
        {
            _area = area;
        }

        public string Area
        {
            get
            {
                return Parent == null
                           ? _area
                           : Parent.Area;
            }
        }


        public virtual string GetRouteName()
        {
            return Parent == null
                       ? string.Format("{0}{1}{2}", Area, Controller, Action)
                       : Parent.GetRouteName() + string.Format("{0}{1}", Controller, Action);
        }


        public static IList<RouteInfo> TreeStructureToList(RouteInfo routeInfo)
        {
            var result = new List<RouteInfo> {routeInfo};
            foreach (var route in routeInfo.Children)
            {
                result.Add(TreeStructureToList(route));
            }
            return result;
        }

        public IList<RouteInfo> TreeStructureToList()
        {
            return TreeStructureToList(this);
        }

        public string GetRouteUrl()
        {
            return string.Empty;
        }

    	public void Update(ICollection<RouteInfo> process)
    	{

    		foreach (var routeInfo in process)
    		{
    			this.Children.Add(routeInfo);
    		}
    	}
    }
}