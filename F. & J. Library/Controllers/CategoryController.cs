using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    public class CategoryController : Controller
    {

        // Testowe dane statyczne
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1"},
            new Category { Id = 2, Name = "Category 2"},
            new Category { Id = 3, Name = "Category 3"}
        };

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(categories.FirstOrDefault(x => x.Id == id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View(new Category());
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            category.Id = categories.Count + 1;
            categories.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category updatedCategory)
        {
            Category category = categories.FirstOrDefault(x => x.Id == id);
            category.Name = updatedCategory.Name;

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Category category = categories.FirstOrDefault(x => x.Id == id);
            categories.Remove(category);

            return RedirectToAction(nameof(Index));
        }
    }
}
