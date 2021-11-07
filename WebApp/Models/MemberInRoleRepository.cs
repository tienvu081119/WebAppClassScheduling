using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class MemberInRoleRepository : BaseRepository
    {
        public MemberInRoleRepository(CSContext context) : base(context) { }

        public int Add(MemberInRole obj)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@MemberId", obj.MemberId),
                new SqlParameter("@RoleId",obj.RoleId)
            };

            return context.Database.ExecuteSqlRaw("Exec SaveMemberInRole @MemberId, @RoleId", parameters);
        }
    }
}
