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

		public IActionResult Edit(int? id) 
		{
			if (id == null || id == 0) 
			{
				return NotFound();
			}

			Category categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return BadRequest();
			}

			return View(categoryFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Name", "Nama dan Display Order tidak boleh sama");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View(obj);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return BadRequest();
			}

			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category obj = _db.Categories.Find(id);

			if (obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("index");
		}

	}
}
