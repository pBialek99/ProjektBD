using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F.___J._Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Author { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Description { get; set; }

        // Klucz obcy -> na ID kategorii
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // właściwość nawigacyjna
        public Category Category { get; set; }

    }
}
