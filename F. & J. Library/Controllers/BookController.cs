using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F.___J._Library.Controllers
{
    public class BookController : Controller
    {
        // Testowe dane statyczne
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "John", Description = "Desc 1", CategoryId = 1 },
            new Book { Id = 2, Title = "Book 2", Author = "Nathan", Description = "Desc 2", CategoryId = 2 },
            new Book { Id = 3, Title = "Book 3", Author = "David", Description = "Desc 3", CategoryId = 3 }
        };

        // GET: BookController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(books.FirstOrDefault(x => x.Id == id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View(new Book());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {      
            var book = books.FirstOrDefault(x => x.Id == id);

            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book updatedBook)
        {
            Book book = books.FirstOrDefault(x => x.Id == id);
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Description = updatedBook.Description;
            book.CategoryId = updatedBook.CategoryId;

            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Book book = books.FirstOrDefault(x => x.Id == id);
            books.Remove(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
