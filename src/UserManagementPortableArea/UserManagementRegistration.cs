using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace UserManagementPortableArea
{
	public class LoginRegistration : PortableAreaRegistration
	{
		public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
		{
			context.MapRoute(
				"Users",
				"users/{controller}/{action}",
				new {controller = "user", action = "index"});

			RegisterTheViewsInTheEmbeddedViewEngine(GetType());
		}

		public override string AreaName
		{
			get { return "Users"; }
		}
	}
}