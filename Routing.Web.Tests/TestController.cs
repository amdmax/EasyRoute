using Routing.Rest.Attributes;

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

	[RestResources(typeof(TestChildAController), typeof (TestRootController))]
	public class TestChildAController : TestController
	{
	}

    [RestResources(typeof(TestChildBController), typeof(TestRootController))]
	public class TestChildBController : TestController
	{
	}
}