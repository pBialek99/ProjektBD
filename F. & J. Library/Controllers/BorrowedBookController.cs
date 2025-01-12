using System.Linq;
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
        //public static List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();
        //static BorrowedBookController()
        //{
        //    foreach (var book in BookController.Books.Where(b => b.IsBorrowed && !borrowedBooks.Any(bb => bb.BookId == b.Id)))
        //    {
        //        borrowedBooks.Add(new BorrowedBook { BookId = book.Id, Book = book });
        //    }
        //}

        // bazodanowy kontekst
        private readonly LibraryDbContext _context;
        public BorrowedBookController(LibraryDbContext context)
        {
            _context = context;
        }


        // GET: BorrowedBookController
        public ActionResult Index()
        {
            return View(_context.BorrowedBooks.ToList());
        }

        // GET: BorrowedBookController/Details/5
        public ActionResult Details(int id)
        {
            BorrowedBook borrowedBook = _context.BorrowedBooks.Find(id);

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
            Book book = _context.Books.FirstOrDefault(b => b.Id == borrowedBook.BookId);
            book.IsBorrowed = true;

            _context.BorrowedBooks.Add(borrowedBook);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: BorrowedBookController/Edit/5
        public ActionResult Edit(int id)
        {
            BorrowedBook borrowedBook = _context.BorrowedBooks.Find(id);

            return View(borrowedBook);
        }

        // POST: BorrowedBookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BorrowedBook updatedBorrowed)
        {
            BorrowedBook existingBorrowedBook = _context.BorrowedBooks.Find(id);

            existingBorrowedBook.BorrowDate = updatedBorrowed.BorrowDate;
            existingBorrowedBook.ReturnDate = updatedBorrowed.ReturnDate;

            // wywala blad powiazania :/
            //_context.BorrowedBooks.Update(updatedBorrowed);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: BorrowedBookController/Delete/5
        public ActionResult Delete(int id)
        {
            BorrowedBook borrowedBook = _context.BorrowedBooks.Find(id);

            return View(borrowedBook);
        }

        // POST: BorrowedBookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BorrowedBook borrowedBook)
        {
            // Fetch the borrowed book from the database by its ID to make sure it's tracked.
            BorrowedBook existingBorrowedBook = _context.BorrowedBooks.Find(id);

            if (existingBorrowedBook != null)
            {
                // Find the corresponding book and set its IsBorrowed flag to false.
                Book book = _context.Books.FirstOrDefault(b => b.Id == existingBorrowedBook.BookId);
                if (book != null)
                {
                    book.IsBorrowed = false;
                }

                // Remove the borrowed book entry from the database.
                _context.BorrowedBooks.Remove(existingBorrowedBook);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
