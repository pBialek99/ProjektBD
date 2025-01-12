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

        // wlasciwosc nawigacyjna dla 'book'
        public ICollection<Book> Books { get; set; }
    }
}
