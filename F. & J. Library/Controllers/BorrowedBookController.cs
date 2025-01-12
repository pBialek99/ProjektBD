using System.Linq;
using F.___J._Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using static System.Reflection.Metadata.BlobBuilder;

namespace F.___J._Library.Controllers
{
    public class BorrowedBookController : Controller
    {
        // bazodanowy kontekst
        private readonly LibraryDbContext _context;
        public BorrowedBookController(LibraryDbContext context)
        {
            _context = context;
        }


        // GET: BorrowedBookController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_context.BorrowedBooks.ToList());
        }

        // GET: BorrowedBookController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            BorrowedBook borrowedBook = _context.BorrowedBooks.Find(id);

            return View(borrowedBook);
        }

        // GET: BorrowedBookController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BorrowedBookController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            BorrowedBook borrowedBook = _context.BorrowedBooks.Find(id);

            return View(borrowedBook);
        }

        // POST: BorrowedBookController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            BorrowedBook borrowedBook = _context.BorrowedBooks.Find(id);

            return View(borrowedBook);
        }

        // POST: BorrowedBookController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BorrowedBook borrowedBook)
        {
            BorrowedBook existingBorrowedBook = _context.BorrowedBooks.Find(id);

            if (existingBorrowedBook != null)
            {
                Book book = _context.Books.FirstOrDefault(b => b.Id == existingBorrowedBook.BookId);
                if (book != null)
                {
                    book.IsBorrowed = false;
                }

                _context.BorrowedBooks.Remove(existingBorrowedBook);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
