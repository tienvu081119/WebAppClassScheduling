using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Room")]
    public class Room
    {
        [Column("RoomId")]
        public int Id { get; set; }

        [Column("RoomNumber")]

        public string Number { get; set; }

        public short Capacity { get; set; }

    }
}
