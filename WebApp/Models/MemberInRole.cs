using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("MemberInRole")]
    public class MemberInRole
    {
       public string MemberId { get; set; }

       public Guid RoleId { get; set; }
    }
}
