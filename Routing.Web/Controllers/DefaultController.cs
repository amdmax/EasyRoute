using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Routing.Rest.Routing;
using Routing.Web.Attributes;

namespace Routing.Web.Controllers
{
    public class RouteHierarhyBuilder
    {
        public RouteInfo BuildHierarchy(Assembly assembly)
        {
            var controllerTypes = assembly.GetTypes().Where(x => x.IsAssignableFrom(typeof (Controller)));

            return new RouteInfo();
        }
    }

    [RootController]
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            return View();
        }

    }

    
}
