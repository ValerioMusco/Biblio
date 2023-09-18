using Biblio_Domain.DTOs;
using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_Domain.Mappers {
    public static class BookMappers {

        public static Book ToEntity(this BookFormDTO dto) {

            return new Book {

                Isbn = dto.Isbn,
                BookName = dto.BookName,
                Description = dto.Description,
                Quantity = dto.Quantity,
                Price = dto.Price,
                Genre = dto.Genre
            };
        }
        public static BookShortDTO toBookShort (this Book book) {

            return new BookShortDTO {

                Isbn = book.Isbn,
                BookName = book.BookName,
                Price = book.Price,
            };
        }
    }

}
