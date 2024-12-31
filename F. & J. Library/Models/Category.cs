using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace F.___J._Library.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        // relacja z tabelą 'Book' - 1 do WIELU
        public ICollection<Book> Books { get; set; }
    }
}
