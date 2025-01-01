using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace F.___J._Library.Models
{
    public class BorrowedBook
    {
        [Key]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        // właściwość nawigacyjna
        // relacja z tabelą 'Book' - 1 do 1
        public Book Book { get; set; }

        // id użytkownika (możliwe do edycji po dodaniu Identity)
        //[ForeignKey("User")]
        //public int UserId { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string FirstName { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        //public string LastName { get; set; }

        // data wypożyczenia
        public DateTime? BorrowDate { get; set; }

        // data oddania
        public DateTime? ReturnDate { get; set; }
    }
}
