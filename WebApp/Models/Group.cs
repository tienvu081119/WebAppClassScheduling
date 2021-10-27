using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Group")]
    public class Group
    {
        [Column("GroupId")]
        public int Id { get; set; }

        [Column("GroupSize")]
        public short Size { get; set; }

        public List<ModuleGroup> ModuleGroups { get; set; }
    }
}
