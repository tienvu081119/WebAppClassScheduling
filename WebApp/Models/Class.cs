using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Class")]
    public class Class
    {
        [Column("ClassId")]

        public int Id { get; set; }

        public int ProfessorId { get; set; }

        public int ModuleId { get; set; }

        public int RoomId { get; set; }

        public int GroupId { get; set; }

        public int TimeslotId { get; set; }
    }
}
