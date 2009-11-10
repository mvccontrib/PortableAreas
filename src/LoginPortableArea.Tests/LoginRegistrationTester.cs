using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.PortableAreas;
using NUnit.Framework;
using Rhino.Mocks;

namespace LoginPortableArea.Tests
{
	[TestFixture]
	public class LoginRegistrationTester
	{
		[Test]
		public void Should_register_the_area_name()
		{
			var reg = new LoginRegistration();
			Assert.That(reg.AreaName, Is.EqualTo("Login"));
		}
		[Test]
		public void Should_register_the_areas_routes()
		{
			var context = new AreaRegistrationContext("foo", new RouteCollection());

			var reg = new LoginRegistration();

			reg.RegisterArea(context, MockRepository.GenerateMock<IApplicationBus>());

			Assert.That(context.Routes.Count, Is.GreaterThan(0));

		}
	}
}