using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProfessorChecked
    {
        [Column("ProfessorId")]
        public int Id { get; set; }

        public string FullName { get; set; }

        public bool Checked { get; set; }
    }
}
