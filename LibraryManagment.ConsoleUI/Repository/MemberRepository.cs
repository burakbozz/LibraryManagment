using LibraryManagment.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagment.ConsoleUI.Repository
{
    internal class MemberRepository : BaseRepository, IMemberRepository
    {
        private List<Member> members;
        public MemberRepository()
        {
            members = Members();
        }
        public Member? Add(Member member)
        {
            members.Add(member);
            return member;

        }

        public List<Member> GetAll()
        {
            return members;
        }

        public Member? GetById(int id)
        {
            Member? member = members.SingleOrDefault(x => x.Id == id);
            return member;
        }

        public Member? Remove(int id)
        {
            Member? deletedMember = GetById(id);

            if (deletedMember is null)
            {
                return null;
            }
            members.Remove(deletedMember);
            return deletedMember;
        }

        public Member? Update(Member member)
        {
            Member? updatedMember = GetById(member.Id);
            if (updatedMember is null)
            {
                return null;
            }
            
            return updatedMember;
        }
    }
}
