﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace F.___J._Library.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Street { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        // relacja z tabelą 'Book' - 1 do WIELU
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
