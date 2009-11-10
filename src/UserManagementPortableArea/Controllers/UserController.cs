using System.Web.Mvc;
using MvcContrib.PortableAreas;
using UserManagementPortableArea.Messages;

namespace UserManagementPortableArea.Controllers
{
	public class UserController : Controller
	{
		public ActionResult Index()
		{
			var message = new UserDisplayQuery {};
			PortableArea.Bus.Send(message);
			return View(message.Result);
		}
	}
}