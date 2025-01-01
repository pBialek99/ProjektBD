using F.___J._Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    public class BorrowedBookController : Controller
    {
        // statyczne dane testowe
        // tworzone w oparciu o ksiazki w tabeli Book
        // daty przypisywane tak o, zeby byly
        public static List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();
        static BorrowedBookController()
        {
            foreach (var book in BookController.books.Where(b => b.IsBorrowed))
            {
                borrowedBooks.Add(new BorrowedBook { BookId = book.Id, Book = book });
            }
        }

        // GET: BorrowedBookController
        public ActionResult Index()
        {
            return View(borrowedBooks);
        }

        // GET: BorrowedBookController/Details/5
        public ActionResult Details(int id)
        {
            BorrowedBook borrowedBook = borrowedBooks.FirstOrDefault(x => x.BookId == id);

            return View(borrowedBook);
        }

        // GET: BorrowedBookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BorrowedBookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BorrowedBook borrowedBook)
        {
            borrowedBook.BookId = borrowedBooks.Max(b => b.BookId) + 1;
            borrowedBooks.Add(borrowedBook);

            return RedirectToAction(nameof(Index));
        }

        // GET: BorrowedBookController/Edit/5
        public ActionResult Edit(int id)
        {
            BorrowedBook borrowedBook = borrowedBooks.FirstOrDefault(b => b.BookId == id);

            return View(borrowedBook);
        }

        // POST: BorrowedBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BorrowedBook updatedBorrowed)
        {
            BorrowedBook borrowedBook = borrowedBooks.FirstOrDefault(b => b.BookId == id);

            borrowedBook.BorrowDate = updatedBorrowed.BorrowDate;
            borrowedBook.ReturnDate = updatedBorrowed.ReturnDate;

            return RedirectToAction(nameof(Index));
        }

        // GET: BorrowedBookController/Delete/5
        public ActionResult Delete(int id)
        {
            var borrowedBook = borrowedBooks.FirstOrDefault(b => b.BookId == id);

            return View(borrowedBook);
        }

        // POST: BorrowedBookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            BorrowedBook borrowedBook = borrowedBooks.FirstOrDefault(b => b.BookId == id);
            borrowedBooks.Remove(borrowedBook);

            Book book = BookController.books.FirstOrDefault(b => b.Id == id);
            book.IsBorrowed = false;

            return RedirectToAction(nameof(Index));
        }
    }
}
