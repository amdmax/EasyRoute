using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Routing;
using NUnit.Framework;
using Routing.Rest.Attributes;
using Routing.Rest.Routing;

namespace Routing.Web.Tests
{
    [RestResources(typeof(TestRegistrationController), null)]
    public class TestRegistrationController
    {
        
    }

    [TestFixture]
    public class RoutesRegistrationTests
    {
        [Test]
        public void TestExportedControllers()
        {
            var controllers = RouteCollectionExtensions.GetControllerTypes(Assembly.GetExecutingAssembly(), typeof (TestRegistrationController));
            Assert.IsNotNull(controllers);
            CollectionAssert.IsNotEmpty(controllers);
            Assert.AreEqual(1, controllers.Count());
        }

        [Test]
        public void TestRegistrationMethod()
        {
            var routeCollection = new RouteCollection();
            routeCollection.RegisterRestControllers(controllerBaseType:typeof(TestRegistrationController));
            CollectionAssert.IsNotEmpty(routeCollection);
            var first = (Route)routeCollection[0];
            StringAssert.EndsWith(@"/{action}", first.Url);
        }
    }
}
