using Microsoft.AspNetCore.Mvc;

namespace CompAereaWeb.Controllers
{
	public class VoosController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
