using Biblio_BLL.Services;
using Biblio_Domain.DTOs;
using BiblioDomain.Entities;
using Biblio_Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_API.FakeControllers {
    public class BookFakeController {

        private readonly BookService _bookService;

        public BookFakeController() {
            
            _bookService = new BookService();
        }

        public Book? Add(BookFormDTO book ) {

            try {

                return _bookService.Add( book.ToEntity() );
            }
            catch (Exception e) {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Book? GetBook(int isbn ) {

            try {

                return _bookService.GetBook( isbn );
            }
            catch (Exception e) {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<BookShortDTO>? GetBooks() {

            return _bookService.GetBooks().Select(b => b.toBookShort()).ToList();
        }

        public bool Update(int isbn,  BookFormDTO book ) {

            try {

                return _bookService.Update( isbn, book.ToEntity() );
            }
            catch (Exception e) {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Delete(int isbn ) {

            try {

                return _bookService.Delete( isbn );
            }
            catch(Exception e) {

                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
