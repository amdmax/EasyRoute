using Routing.Web.Attributes;

namespace Routing.Web.Tests
{
	// all this hierarchy is made for testing purposes only
	public class TestController
	{
	}

	[RootController]
	public class TestRootController : TestController
	{
	}

	[RootController]
	public class TestRoot2Controller : TestController
	{
	}

	[RestResourcesController(typeof (TestRootController))]
	public class TestChildAController : TestController
	{
	}

	[RestResourcesController(typeof (TestRootController))]
	public class TestChildBController : TestController
	{
	}
}