using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    public class CategoryController : Controller
    {
        // statyczna lista
        public static List<Category> categories = new List<Category>
        {
            new Category {Id = 1, Name = "Genre 1"},
            new Category {Id = 2, Name = "Genre 2"},
            new Category {Id = 3, Name = "Genre 3"},
        };

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            Console.WriteLine($"Looking for category with id {id}.");
            Category category = categories.FirstOrDefault(c => c.Id == id);

            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            category.Id = categories.Max(c => c.Id) + 1;
            categories.Add(category);

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category updatedCategory)
        {
            Category category = categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                // Obsłuż sytuację, gdy kategoria nie została znaleziona
                ModelState.AddModelError(string.Empty, "Category not found.");
                return View(updatedCategory);
            }

            category.Name = updatedCategory.Name;

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = categories.FirstOrDefault(c => c.Id == id);

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Category category = categories.FirstOrDefault(c => c.Id == id);
            categories.Remove(category);

            return RedirectToAction(nameof(Index));
        }
    }
}
