using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Models
{
    public class MemberRepository : BaseRepository
    {
        public MemberRepository(CSContext context) : base(context) { }

        public List<Member> Search(string q)
        {
            return context.Members.Where(p=>p.Username.Contains(q)).ToList();
        }


        public List<Member> GetMembers()
        {
            return context.Members.ToList();
        }

        //Add member

        public int Add(Member obj)
        {
            context.Members.Add(obj);
            return context.SaveChanges();
        }

        public Member GetMemberById(string id)
        {
            return context.Members.Find(id);
        }

        public Member Login(LoginModel obj)
        {
            return context.Members.Where(p => (p.Username == obj.Username || p.Email == obj.Username)
            && p.Password == Helper.Hash(obj.Password)).FirstOrDefault();
        }
    }
}
