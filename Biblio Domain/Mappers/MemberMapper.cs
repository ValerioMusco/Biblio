using Biblio_Domain.DTOs;
using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_Domain.Mappers {
    public static class MemberMapper {

        public static Member ToEntity( this MemberFormDTO dto ) {

            return new Member {

                UserName = dto.UserName,
                Password = dto.Password,
                Privileges = dto.Privileges
            };
        }
    }
}
