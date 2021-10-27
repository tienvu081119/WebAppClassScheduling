using System.ComponentModel.DataAnnotations.Schema;


namespace WebApp.Models
{
    [Table("ModuleProfessor")]
    public class ModuleProfessor
    {
        public int ModuleId { get; set; }
        public int ProfessorId { get; set; }    
        public Module Module { get; set; }
        public Professor Professor { get; set; }
    }
}
