using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Professor")]
    public class Professor
    {
        [Column("ProfessorId")]
        public int Id { get; set; }
        public string FullName { get; set; }
   
    }
}
