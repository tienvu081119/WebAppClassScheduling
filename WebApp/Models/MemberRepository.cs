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

        public int Update(ResetPassword obj)
        {
            Member member = context.Members.Where(p => p.Token == obj.Token).FirstOrDefault();
            if(member != null)
            {
                member.Password = Helper.Hash(obj.NewPassword);
                member.Token = null;
                context.Members.Update(member);
                return context.SaveChanges();
            }
            return 0;

        }

        public int Update(ForgotPassword obj)
        {
            Member member = context.Members.Where(p => p.Email == obj.Email).FirstOrDefault();
            if (member != null)
            {
              
                member.Token = obj.Token;
                context.Members.Update(member);
                return context.SaveChanges();
            }
            return 0;
        }


        public int ChangePassword(ChangeModel obj)
        {
            Member member = context.Members.Where(p => p.Id == obj.MemberId && p.Password == Helper.Hash(obj.OldPassword)).FirstOrDefault();
            if(member != null)
            {
                member.Password = Helper.Hash(obj.NewPassword);
                context.Members.Update(member);
                return context.SaveChanges();
            }
            return 0;

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
