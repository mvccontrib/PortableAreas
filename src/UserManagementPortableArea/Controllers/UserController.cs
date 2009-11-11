using System.Web.Mvc;
using MvcContrib;
using UserManagementPortableArea.Messages;

namespace UserManagementPortableArea.Controllers
{
	public class UserController : Controller
	{
		public ActionResult Index()
		{
			var message = new UserDisplayQuery {};
			Bus.Send(message);
			return View(message.Result);
		}
	}
}