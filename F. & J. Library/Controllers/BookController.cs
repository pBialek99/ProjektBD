using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F.___J._Library.Controllers
{
    public class BookController : Controller
    {
        // statyczne dane testowe
        private static List<Book> books = new List<Book>
        {
            new Book {Id = 1, Title = "Test Book 1", Author = "Author 1", Description = "Description 1", IsBorrowed = false, CategoryId = 1, PublisherId = 1},
            new Book {Id = 2, Title = "Test Book 2", Author = "Author 2", Description = "Description 2", IsBorrowed = false, CategoryId = 2, PublisherId = 2},
            new Book {Id = 3, Title = "Test Book 3", Author = "Author 3", Description = "Description 3", IsBorrowed = false, CategoryId = 3, PublisherId = 3}
        };

        // GET: BookController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            Book book = books.FirstOrDefault(x => x.Id == id);

            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);

            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book updatedBook)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Description = updatedBook.Description;
            book.IsBorrowed = updatedBook.IsBorrowed;
            book.CategoryId = updatedBook.CategoryId;
            book.PublisherId = updatedBook.PublisherId;

            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = books.First(b => b.Id == id);

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            books.Remove(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
