using Microsoft.EntityFrameworkCore;

namespace F.___J._Library.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext>options) : base(options) { }
        
        // tabele do bazy danych
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
