using System.Web.Mvc;

using MvcContrib.PortableAreas;

namespace AssemblyVersionPortableArea
{
	public class LoginRegistration : PortableAreaRegistration
	{
		public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
		{
			context.MapRoute(
				"AssemblyVersion",
				"AssemblyVersion/{controller}/{action}",
				new {controller = "home", action = "index"});

			RegisterTheViewsInTheEmbeddedViewEngine(GetType());
		}

		public override string AreaName
		{
			get { return "AssemblyVersion"; }
		}
	}
}