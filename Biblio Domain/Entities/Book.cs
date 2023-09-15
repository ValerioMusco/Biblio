using BiblioDomain.Entities;
using BiblioDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioDomain.Entities {
    public class Book {

        public int Isbn { get; set; }
        public string BookName { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Genre Genre { get; set; }
    }
}