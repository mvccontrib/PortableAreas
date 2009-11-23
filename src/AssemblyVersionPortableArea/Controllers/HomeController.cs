using System.Web.Mvc;

namespace AssemblyVersionPortableArea.Controllers
{
	public class HomeController:Controller
	{
		public object Index()
		{
			return System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies();
		}
		
	}
}