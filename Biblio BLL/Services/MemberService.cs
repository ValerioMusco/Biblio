using Biblio_DAL.Repositories;
using BiblioDAL.Repositories;
using BiblioDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio_BLL.Services {
    public class MemberService {

        private readonly IMemberRepository _memberRepository;

        public MemberService(){

            _memberRepository = new MemberRepository();
        }
        public Member Add( Member member ) {
            return _memberRepository.Create( member );
        }

        public Member GetMember( int id ) {
            return _memberRepository.ReadOne( id );
        }

        public List<Member> GetMembers() {
            return _memberRepository.ReadAll().ToList();
        }
        public bool Update( int id, Member member ) {

            return _memberRepository.Update( id, member );
        }

        public bool Delete( int id ) {

            return _memberRepository.Delete( id );
        }
    }
}
