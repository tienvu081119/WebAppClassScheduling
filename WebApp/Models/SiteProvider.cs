using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{

    //Dispose
    //Khá quan trọng
    public class SiteProvider 
    {
        CSContext context;

        public SiteProvider(CSContext context)
        {
            //Khuyet (do Constructor)
            //Tu dong khoi tao
            this.context = context;
        }

        //Fields
        RoleRepository role;
        MemberRepository member;
        MemberInRoleRepository memberInRole;


        public MemberInRoleRepository MemberInRole
        {
            get
            {
                if(memberInRole is null)
                {
                    memberInRole = new MemberInRoleRepository(context);
                }
                return memberInRole;
            }
        }

        public MemberRepository Member
        {
            get
            {
                if(member is null)
                {
                    member = new MemberRepository(context);
                }
                return member;
            }
        }

        public RoleRepository Role
        {
            get
            {
                if(role is null)
                {
                    role = new RoleRepository(context);
                }
                return role;
            }
        }

        public void DoSomeThing()
        {
            Console.WriteLine("Do Something ******************");
        }

        public void Dispose()
        {
            Console.WriteLine("************************");
            Console.WriteLine("site Provider Auto Disposable");
        }
    }
}
