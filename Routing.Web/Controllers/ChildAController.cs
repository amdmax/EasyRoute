using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Routing.Web.Attributes;

namespace Routing.Web.Controllers
{
    [RestResourcesController(typeof(DefaultController))]
    public class ChildAController : Controller
    {
        //
        // GET: /ChildA/
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
