using System.Web.Mvc;
using System.Web.Security;

namespace LoginPortableArea.Controllers
{
	public class LogoutActionResult : ActionResult
	{
		public override void ExecuteResult(ControllerContext context)
		{
			FormsAuthentication.SignOut();
			new RedirectResult("~/").ExecuteResult(context);
		}
	}
}