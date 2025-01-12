using F.___J._Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace F.___J._Library.Controllers
{
    public class BookController : Controller
    {
        // bazodanowy kontekst
        private readonly LibraryDbContext _context;
        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: BookController
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        // GET: BookController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(_context.Books.Find(id));
        }

        // GET: BookController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name");

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            book.IsBorrowed = false;
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", book.CategoryId);
            ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name", book.PublisherId);

            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book updatedBook)
        {
            _context.Books.Update(updatedBook);


            if (updatedBook.IsBorrowed && !_context.BorrowedBooks.Any(bb => bb.BookId == id))
            {
                var borrowedBook = new BorrowedBook
                {
                    BookId = id,
                    BorrowDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(30)
                };
                _context.BorrowedBooks.Add(borrowedBook);
            }

            if (!updatedBook.IsBorrowed)
            {
                var borrowedBook = _context.BorrowedBooks.SingleOrDefault(bb => bb.BookId == id);
                if (borrowedBook != null)
                {
                    _context.BorrowedBooks.Remove(borrowedBook);
                }
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Book book = _context.Books.Find(id);


            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Akcja do wypozyczenia ksiazki
        [Authorize(Roles = "User")]
        public ActionResult Borrow(int id)
        {
            Book book = _context.Books.Find(id);
            book.IsBorrowed = true;

            BorrowedBook borrowedBook = new BorrowedBook
            {
                BookId = book.Id,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(30),
            };

            _context.BorrowedBooks.Add(borrowedBook);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Akcja do zwrotu ksiazki
        [Authorize(Roles = "User")]
        public ActionResult Return(int id)
        {
            Book book = _context.Books.Find(id);
            BorrowedBook borrowedBook = _context.BorrowedBooks.Find(id);

            _context.BorrowedBooks.Remove(borrowedBook);
            book.IsBorrowed = false;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
