using F.___J._Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        // bazodanowy kontekst
        private readonly LibraryDbContext _context;
        public CategoryController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            Category category = _context.Categories.Find(id);

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
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _context.Categories.Find(id);

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
            //Category category = _context.Categories.Find(id);

            _context.Categories.Update(updatedCategory);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
