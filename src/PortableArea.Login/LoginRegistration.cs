using System.Web.Mvc;
using LoginPortableArea.Messages;
using MvcContrib.PortableAreas;

namespace LoginPortableArea
{
	public class LoginRegistration : PortableAreaRegistration
	{
		public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
		{
			bus.Send(new RegistrationMessage("Registering Login Portable Area"));

			context.MapRoute(
				"login",
				"login/{controller}/{action}",
				new {controller = "login", action = "index"});

			RegisterTheViewsInTheEmbeddedViewEngine(GetType());
		}

		public override string AreaName
		{
			get { return "Login"; }
		}
	}
}