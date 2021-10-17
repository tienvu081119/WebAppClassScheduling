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
        [Column("ProfessorsId")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
