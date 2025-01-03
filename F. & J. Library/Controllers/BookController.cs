using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace F.___J._Library.Controllers
{
    public class BookController : Controller
    {
        // statyczne dane testowe
        public static List<Book> books = new List<Book>
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
            Book book = books.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryController.categories, "Id", "Name");
            ViewBag.Publishers = new SelectList(PublisherController.publishers, "Id", "Name");

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            book.IsBorrowed = false;
            books.Add(book);

            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            ViewBag.Categories = new SelectList(CategoryController.categories, "Id", "Name", book.CategoryId);
            ViewBag.Publishers = new SelectList(PublisherController.publishers, "Id", "Name", book.PublisherId);

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
            var book = books.FirstOrDefault(b => b.Id == id);

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

        // Akcja do wypozyczenia ksiazki
        public ActionResult Borrow(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            book.IsBorrowed = true;
            BorrowedBookController.borrowedBooks.Add(new BorrowedBook { BookId = book.Id, Book = book, BorrowDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(30) });

            return RedirectToAction("Index");
        }

        // Akcja do zwrotu ksiazki
        public ActionResult Return(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id && b.IsBorrowed);
            BorrowedBook borrowedBook = BorrowedBookController.borrowedBooks.FirstOrDefault(b => b.BookId == id);
            BorrowedBookController.borrowedBooks.Remove(borrowedBook);

            book.IsBorrowed = false;

            return RedirectToAction("Index");
        }
    }
}
