using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Routing.Rest;
using Routing.Rest.Attributes;
using Routing.Web.Attributes;
using Routing.Web.Configuration;
using Routing.Web.TestHierarchy;
using Routing.Web.Tests;

namespace Routing.Web.TestTwoRootHierarchy
{
    [RootController]
    public class RootAController : TestController
    {
    }

    [RootController]
    public class RootBController : TestController
    {
    }
}

namespace Routing.Web.TestHierarchy
{
    [RootController]
    public class RootController : TestController
    {
    }

    [AreaRootController("Area1")]
    public class Area1Controller : TestController
    {
    }

    [RestResourcesController(typeof (Area1Controller))]
    public class ResourcesController : TestController
    {
    }

    [RestResourcesController(typeof (RootController))]
    public class Resources2Controller : TestController
    {
    }
}

namespace Routing.Web.Tests
{
    [TestFixture]
    public class ControllerNavigatorTests
    {
        [Test, Explicit("Need to finish development")]
        public void TestControllerAttributeObtainment()
        {
            var correctTypes =
                Assembly.GetExecutingAssembly().GetTypes().Except(new List<Type> {typeof (TestRoot2Controller)});

            var getRoutes = ControllerNavigator.TransformControllersToRouteInfo(correctTypes, typeof (TestController));
            StringAssert.AreEqualIgnoringCase(typeof (TestRootController).Name, getRoutes.GetRouteName());
            Assert.AreEqual(2, getRoutes.Children.Count);
            StringAssert.AreEqualIgnoringCase(typeof (TestChildAController).Name,
                                              getRoutes.Children.First().GetRouteName());
            StringAssert.AreEqualIgnoringCase(typeof (TestChildBController).Name,
                                              getRoutes.Children.Skip(1).First().GetRouteName());
        }

        [Test]
        public void AssertTwoRootControllersThrows()
        {
            Assert.Throws(typeof (InvalidOperationException),
                          () =>
                          ControllerNavigator.TransformControllersToRouteInfo(Assembly.GetExecutingAssembly(),
                                                                              typeof (TestController),
                                                                              "Routing.Web.TestTwoRootHierarchy"));
        }

        [Test]
        public void AssertRootControllerGoesFirst()
        {
            var routeRoot = ControllerNavigator.TransformControllersToRouteInfo(Assembly.GetExecutingAssembly(),
                                                                                typeof (TestController),
                                                                                "Routing.Web.TestHierarchy");
            CollectionAssert.IsNotEmpty(routeRoot.Children);
            foreach (var child in routeRoot.Children)
                Assert.IsNotNull(child.Area);

            Assert.That(routeRoot.Children.First().Controller, Is.Null);
            Assert.That(routeRoot.Children.First().Area, Is.Not.Empty);
            Assert.That(routeRoot.Children.First().Children.First().Controller,
                        Is.EqualTo(typeof (ResourcesController).Name));
            Assert.That(routeRoot.Children.Skip(1).First().Controller, Is.EqualTo(string.Empty));
        }
    }
}