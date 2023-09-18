using Biblio_DAL.Repositories;
using BiblioDAL.Repositories;
using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_BLL.Services {
    public class BookService {

        private readonly IBookRepository _bookRepository;

        public BookService(){
            _bookRepository = new BookRepository();
        }

        public Book Add(Book book ) {
            return _bookRepository.Create( book );
        }

        public Book GetBook(int isbn ) {
            return _bookRepository.ReadOne( isbn );
        }

        public IEnumerable<Book> GetBooks() {
            return _bookRepository.ReadAll();
        }

        public bool Update(int isbn, Book book) {

            return _bookRepository.Update( isbn, book ); 
        }

        public bool Delete(int isbn) {

            return _bookRepository.Delete( isbn );
        }
    }
}
