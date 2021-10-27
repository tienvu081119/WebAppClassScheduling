
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Module")]
    public class Module
    {
        [Column("ModuleId")]
        public int Id { get; set; }

        [Column("ModuleCode")]
        public string Code { get; set; }

        [Column("ModuleName")]
        public string Name { get; set; }    
        public List<ModuleProfessor> ModuleProfessors { get; set; }

    }
}
