using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    public class PublisherController : Controller
    {
        public static List<Publisher> publishers = new List<Publisher>
        {
            new Publisher {Id = 1, Name = "Publisher 1", Street = "Krakowska 1", City = "Cracow", Country = "Poland", PhoneNumber = "1", Email = "sample@mail1.com"},
            new Publisher {Id = 2, Name = "Publisher 2", Street = "Krakowska 2", City = "Cracow", Country = "Poland", PhoneNumber = "2", Email = "sample@mail2.com"},
            new Publisher {Id = 3, Name = "Publisher 3", Street = "Krakowska 3", City = "Cracow", Country = "Poland", PhoneNumber = "3", Email = "sample@mail3.com"}
        };

        // GET: PublisherController
        public ActionResult Index()
        {
            return View(publishers);
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int id)
        {
            Publisher publisher = publishers.FirstOrDefault(b => b.Id == id);

            return View(publisher);
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
            publisher.Id = publishers.Max(p => p.Id) + 1;
            publishers.Add(publisher);

            return RedirectToAction(nameof(Index));
        }

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int id)
        {
            Publisher publisher = publishers.FirstOrDefault(p => p.Id == id);

            return View(publisher);
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Publisher updatedPublisher)
        {
            Publisher publisher = publishers.FirstOrDefault(p => p.Id == id);

            publisher.Name = updatedPublisher.Name;
            publisher.Street = updatedPublisher.Street;
            publisher.City = updatedPublisher.City;
            publisher.Country = updatedPublisher.Country;
            publisher.PhoneNumber = updatedPublisher.PhoneNumber;
            publisher.Email = updatedPublisher.Email;

            return RedirectToAction(nameof(Index));
        }

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int id)
        {
            Publisher publisher = publishers.FirstOrDefault(p => p.Id == id);


            return View(publisher);
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Publisher publisher = publishers.FirstOrDefault(p => p.Id == id);
            publishers.Remove(publisher);

            return RedirectToAction(nameof(Index));
        }
    }
}
