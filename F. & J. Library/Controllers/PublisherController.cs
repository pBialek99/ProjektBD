using F.___J._Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    public class PublisherController : Controller
    {
        // bazodanowy kontekst
        private readonly LibraryDbContext _context;
        public PublisherController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: PublisherController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_context.Publishers.ToList());
        }

        // GET: PublisherController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(_context.Publishers.Find(id));
        }

        // GET: PublisherController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: PublisherController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Publisher publisher = _context.Publishers.Find(id);

            return View(publisher);
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Publisher updatedPublisher)
        {
            _context.Publishers.Update(updatedPublisher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: PublisherController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Publisher publisher = _context.Publishers.Find(id);


            return View(publisher);
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
