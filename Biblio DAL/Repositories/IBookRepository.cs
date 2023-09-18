using Biblio_DAL.Repositories;
using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioDAL.Repositories {
    public interface IBookRepository : IGenericRepository<Book, int> {

        Book Create( Book book );
        bool Update( int id, Book book );
    }
}
