using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RoleChecked
    {
        [Column("RoleId")]

        public Guid Id { get; set; }

        [Column("RoleName")]

        public string Name { get; set; }

        public bool Checked { get; set; }
    }
}
