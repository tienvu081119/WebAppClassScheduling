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
        AccessRepository access;
        ProvinceRepository province;
        DistrictRepository district;
        WardRepository ward;
        SuperstoreRepository superstore;

        public SuperstoreRepository Superstore
        {
            get
            {
                if(superstore is null)
                {
                    superstore = new SuperstoreRepository(context);

                }return superstore;
            }
        }

        public WardRepository Ward
        {
            get
            {
                if(ward is null)
                {
                    ward = new WardRepository(context);
                }
                return ward;
            }
        }

        public DistrictRepository District
        {
            get
            {
                if(district is null)
                {
                    district = new DistrictRepository(context);
                }
                return district;
            }           
        }

        public ProvinceRepository Province
        {
            get
            {
                if(province is null)
                {
                    province = new ProvinceRepository(context);
                }
                return province;
            }
        }

        public AccessRepository Access
        {
            get
            {
                if(access is null)
                {
                    access = new AccessRepository(context);
                }
                return access;
            }
        }

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
