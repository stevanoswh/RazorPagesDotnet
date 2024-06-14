using Microsoft.AspNetCore.Mvc;
using Upskilling.DataAccess.Data;
using Upskilling.DataAccess.Repository.IRepository;
using Upskilling.Models;

namespace Upskilling.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();

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
				_unitOfWork.Category.Add(obj);
				_unitOfWork.Save();
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

			Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
				_unitOfWork.Category.Update(obj);
				_unitOfWork.Save();
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

			Category categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
			if (categoryFromDb == null)
			{
				return BadRequest();
			}

			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category obj = _unitOfWork.Category.Get(u => u.Id == id);

			if (obj == null)
			{
				return NotFound();
			}
			_unitOfWork.Category.Remove(obj);
			_unitOfWork.Save();
			return RedirectToAction("index");
		}

	}
}
