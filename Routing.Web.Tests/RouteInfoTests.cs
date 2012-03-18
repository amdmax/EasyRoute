using System.Collections.ObjectModel;
using NUnit.Framework;
using Routing.Rest.Routing;

namespace Routing.Web.Tests
{
    [TestFixture]
    public class RouteInfoTests
    {
        private string _controller;
        private string _action;
        private string _childaction;
        private string _childcontroller;
        private string _area;
        private const string InfoControllerName = "info";
        private const string TestControllerName = "test";
        private const string TestAControllerName = "testa";

        [Test]
        public void GetRoutesHierarchyTest()
        {
            RouteInfo info = new RouteInfo {Controller = InfoControllerName};
            var testRoute = new RouteInfo {Controller = TestControllerName};
            var testRouteA = new RouteInfo {Controller = TestAControllerName};
            info.Children.Add(testRoute);
            info.Children.Add(testRouteA);

            var list = testRoute.TreeStructureToList();
            Assert.AreEqual(1, list.Count);
            StringAssert.AreEqualIgnoringCase(list[0].Controller, testRoute.Controller);

            var listA = testRouteA.TreeStructureToList();
            Assert.AreEqual(1, listA.Count);
            StringAssert.AreEqualIgnoringCase(listA[0].Controller, testRouteA.Controller);

            var infoList = info.TreeStructureToList();
            Assert.AreEqual(3, infoList.Count);
        }

        [Test]
        public void GetRouteNameTest()
        {

            _controller = "_controllerType";
            _action = "Action";
            _area = "Area";
            RouteInfo info = new RouteInfo(_area) { Controller = _controller, Action = _action };
            StringAssert.AreEqualIgnoringCase(_area + _controller + _action, info.GetRouteName());

            _childaction = "ChildAction";
            _childcontroller = "ChildController";
            var childInfo = new RouteInfo(info) {Controller = _childcontroller, Action = _childaction};
            StringAssert.AreEqualIgnoringCase(info.GetRouteName() + _childcontroller+_childaction, childInfo.GetRouteName());
        }

        [Test]
        public void AssertChildAreaIsParentArea()
        {
            _controller = "_controllerType";
            _action = "Action";
            _area = "Area";
            RouteInfo info = new RouteInfo(_area) { Controller = _controller, Action = _action };
            StringAssert.AreEqualIgnoringCase(_area + _controller + _action, info.GetRouteName());

            _childaction = "ChildAction";
            _childcontroller = "ChildController";
            var childInfo = new RouteInfo(info) { Controller = _childcontroller, Action = _childaction };
            StringAssert.AreEqualIgnoringCase(info.GetRouteName() + _childcontroller + _childaction, childInfo.GetRouteName());

            StringAssert.AreEqualIgnoringCase(info.Area, childInfo.Area);
        }

    }
}