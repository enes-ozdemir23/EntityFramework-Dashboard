using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreContext _context;

        public CategoryController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            category.CategoryStatus = false;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value=_context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values=_context.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            var values = _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult ReverseCategory()
        {
            var categoryValues=_context.Categories.First();
            ViewBag.v = categoryValues.CategoryName;
            var values = _context.Categories.OrderBy(x => x.CategoryId).Reverse().ToList();
            var categoryValues2 = _context.Categories.SingleOrDefault(x => x.CategoryName == "Masaüstü Bilgisayar");
            ViewBag.v2=categoryValues2.CategoryStatus + " " + categoryValues2.CategoryId.ToString();
            return View(values);
        }

    }
}
