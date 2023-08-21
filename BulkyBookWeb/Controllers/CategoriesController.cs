using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
	public class CategoriesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
