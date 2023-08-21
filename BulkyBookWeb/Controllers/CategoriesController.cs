using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
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
			//var categories = context.Categories.ToList();
			IEnumerable <Category> categories = context.Categories;
			return View(categories);
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
