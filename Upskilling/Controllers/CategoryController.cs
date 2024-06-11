using Microsoft.AspNetCore.Mvc;
using Upskilling.Data;
using Upskilling.Models;

namespace Upskilling.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.ToList();

			return View(objCategoryList);
		}

		public IActionResult Create() 
		{ 
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString()) 
			{
				ModelState.AddModelError("Name", "Nama dan Display Order tidak boleh sama");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View();
		}
	}
}
