using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ApplicationDbContext context;

		public CategoriesController(ApplicationDbContext context)
        {
			this.context = context;
		}

        public IActionResult Index()
		{
			var categories = context.Categories.ToList();

			return View(categories);
		}
	}
}
