using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Routing.Rest.Attributes;
using Routing.Web.Attributes;

namespace Routing.Web.Controllers
{
	[AreaRootController("Some")]
    [RestResourcesController(typeof(DefaultController))]
    public class ChildBController : Controller
    {
        //
        // GET: /ChildB/
        [GetRestMethod]
        public ActionResult Index()
        { 
            return View();
        }

        [PostRestMethod]
        public ActionResult Index2()
        {
            return new EmptyResult();
        }
    }
   
}
