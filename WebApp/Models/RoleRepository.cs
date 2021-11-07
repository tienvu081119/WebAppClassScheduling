using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(CSContext context) : base(context) { }

        public List<Role> GetRolesByMemberId(string id)
        {
            return context.Roles.FromSqlRaw("Exec GetRolesByMemberId @Id", new SqlParameter("@Id",id)).ToList();
        }


        public int Add(Role obj)
        {
            context.Roles.Add(obj);
            return context.SaveChanges();
        }

        public List<RoleChecked> GetRoleCheckeds(string id)
        {
            return context.RoleCheckeds.FromSqlRaw("EXEC GetRolesByMember @Id", new SqlParameter("@Id", id)).ToList();
        }

        public List<Role> GetRoles()
        {
            return context.Roles.ToList();
        }
    }
}
