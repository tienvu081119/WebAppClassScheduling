using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Role")]
    public class Role
    {
        [Column("RoleId")]
        public Guid Id { get; set; }

        [Column("RoleName")]
        public string Name { get; set; }
    }
}
