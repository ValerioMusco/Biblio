using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_DAL.Repositories {
    public interface IMemberRepository : IGenericRepository<Member, int>{

        Member Create(Member member);
        bool Update( int id, Member member);
    }
}
