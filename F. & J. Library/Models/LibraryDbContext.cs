using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace F.___J._Library.Models
{
    public class LibraryDbContext : IdentityDbContext<DefaultUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Zarejestruj konfigurację dla DefaultUser
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }

        private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<DefaultUser>
        {
            public void Configure(EntityTypeBuilder<DefaultUser> builder)
            {
                builder.Property(x => x.FirstName).HasMaxLength(50);
                builder.Property(x => x.LastName).HasMaxLength(50);
                builder.Property(x => x.Street).HasMaxLength(50);
                builder.Property(x => x.City).HasMaxLength(50);
                builder.Property(x => x.PhoneNumber).HasMaxLength(9);
            }
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext>options) : base(options) { }
        
        // tabele do bazy danych
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
