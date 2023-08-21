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

		// GET
		public IActionResult Create()
		{
			return View();
		}

		// POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				context.Categories.Add(category);
				context.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(category);
		}
	}
}
