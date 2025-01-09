using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    public class PublisherController : Controller
    {
        //public static List<Publisher> publishers = new List<Publisher>
        //{
        //    new Publisher {Id = 1, Name = "Publisher 1", Street = "Krakowska 1", City = "Cracow", Country = "Poland", PhoneNumber = "1", Email = "sample@mail1.com"},
        //    new Publisher {Id = 2, Name = "Publisher 2", Street = "Krakowska 2", City = "Cracow", Country = "Poland", PhoneNumber = "2", Email = "sample@mail2.com"},
        //    new Publisher {Id = 3, Name = "Publisher 3", Street = "Krakowska 3", City = "Cracow", Country = "Poland", PhoneNumber = "3", Email = "sample@mail3.com"}
        //};

        // bazodanowy kontekst
        private readonly LibraryDbContext _context;
        public PublisherController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: PublisherController
        public ActionResult Index()
        {
            return View(_context.Publishers.ToList());
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Publishers.Find(id));
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int id)
        {
            Publisher publisher = _context.Publishers.Find(id);

            return View(publisher);
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Publisher updatedPublisher)
        {
            _context.Publishers.Update(updatedPublisher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int id)
        {
            Publisher publisher = _context.Publishers.Find(id);


            return View(publisher);
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
