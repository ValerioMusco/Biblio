using BiblioDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_Domain.DTOs {
    public class MemberFormDTO {

        public string UserName { get; set; }
        public string Password { get; set; }
        public Privileges Privileges { get; set; }
    }
}
