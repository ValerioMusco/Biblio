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
    public class MemberFakeController {

        private readonly MemberService _memberService;

        public MemberFakeController() {

            _memberService = new MemberService();
        }

        public Member? Add( MemberFormDTO member ) {

            try {

                return _memberService.Add( member.ToEntity() );
            }
            catch( Exception e ) {

                Console.WriteLine( e.Message );
                return null;
            }
        }

        public Member? GetMember( int id ) {

            try {

                return _memberService.GetMember( id );
            }
            catch( Exception e ) {

                Console.WriteLine( e.Message );
                return null;
            }
        }

        public List<Member>? GetMembers() {

            return _memberService.GetMembers();
        }

        public bool Update( int id, MemberFormDTO member ) {

            try {

                return _memberService.Update( id, member.ToEntity() );
            }
            catch( Exception e ) {

                Console.WriteLine( e.Message );
                return false;
            }
        }

        public bool Delete( int id ) {

            try {

                return _memberService.Delete( id );
            }
            catch( Exception e ) {

                Console.WriteLine( e.Message );
                return false;
            }
        }
    }
}
