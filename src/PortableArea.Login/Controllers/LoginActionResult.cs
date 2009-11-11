using System.Web.Mvc;
using System.Web.Security;

namespace LoginPortableArea.Controllers
{
	public class LoginActionResult : ActionResult
	{
		private string _username;

		public LoginActionResult(string username)
		{
			_username = username;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			FormsAuthentication.RedirectFromLoginPage(_username,false);
		}
	}
}