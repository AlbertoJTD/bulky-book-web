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
			IEnumerable<Category> categories = context.Categories;
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
			if (category.Name == category.DisplayOrder.ToString())
			{
				//ModelState.AddModelError("CustomError", "DisplayOrder cannot be the same as Name field");
				// It will appear at the bottom of the Name field.
				ModelState.AddModelError("Name", "DisplayOrder cannot be the same as Name field");
			}

			if (ModelState.IsValid)
			{
				context.Categories.Add(category);
				context.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(category);
		}

		[HttpGet("{id:int}")]
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0) return NotFound();

			var category = context.Categories.FirstOrDefault(x => x.Id == id);

			if (category == null) return NotFound();

			return View(category);
		}
	}
}
