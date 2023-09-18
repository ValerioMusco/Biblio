using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_DAL.Repositories {
    public interface IGenericRepository<T, U> where T : class {

        T ReadOne(U id);
        IEnumerable<T> ReadAll();
        bool Delete(U id);
    }
}
