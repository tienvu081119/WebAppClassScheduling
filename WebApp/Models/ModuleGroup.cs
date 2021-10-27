using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("ModuleGroup")]
    public class ModuleGroup
    {
        public int ModuleId { get; set; }
        public int GroupId { get; set; }
        public Module Module { get; set; }
        public Group Group { get; set; }

    }
}
