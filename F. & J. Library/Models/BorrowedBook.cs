using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace F.___J._Library.Models
{
    public class BorrowedBook
    {
        [Key]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        // data wypożyczenia
        public DateTime? BorrowDate { get; set; }

        // data oddania
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("DefaultUser")]
        public string UserId { get; set; }

        // właściwość nawigacyjna
        // relacja z tabelą 'AspNetUsers' - 1 do 1
        public Book Book { get; set; }

        // właściwość nawigacyjna
        // relacja z tabelą 'User' - 1 do 1
        public DefaultUser DefaultUser { get; set; }
    }
}
