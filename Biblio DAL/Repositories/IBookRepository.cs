using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioDAL.Repositories {
    public interface IBookRepository {

        Book Create( Book book );
        Book ReadOne( int id );
        IEnumerable<Book> ReadAll();
        bool Update( int id, Book book );
        bool Delete( int id );
    }
}
