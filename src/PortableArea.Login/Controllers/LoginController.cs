using System.Web.Mvc;
using System.Web.Security;
using LoginPortableArea.Messages;
using LoginPortableArea.Models;
using MvcContrib;
using MvcContrib.PortableAreas;

namespace LoginPortableArea.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(LoginInput loginInput)
		{
			if (ModelState.IsValid)
			{
				var message = new LoginInputMessage {Input = loginInput, Result = new LoginResult()};

				Bus.Send(message);

				if (message.Result.Success)
				{
					FormsAuthentication.RedirectFromLoginPage(loginInput.Username, false);
					return null;
				}

				ModelState.AddModelError("model", message.Result.Message);
			}
			return View(loginInput);
		}

		[HttpGet]
		public ActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ForgotPassword(ForgotPasswordInput forgotPasswordInput)
		{
			if (ModelState.IsValid)
			{
				var message = new ForgotPasswordInputMessage {Input = forgotPasswordInput, Result = new ForgotPasswordResult()};

				Bus.Send(message);

				if (message.Result.Success)
				{
					return View("forgotpasswordsent", (object) message.Result.Message);
				}

				ModelState.AddModelError("model", message.Result.Message);
			}
			return View(forgotPasswordInput);
		}
	}
}