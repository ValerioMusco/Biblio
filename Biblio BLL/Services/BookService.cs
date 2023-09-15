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

        public Book getBook(int isbn ) {
            return _bookRepository.ReadOne( isbn );
        }

        public List<Book> getBooks() {
            return _bookRepository.ReadAll().ToList();
        }
    }
}
