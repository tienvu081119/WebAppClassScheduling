using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Timeslot")]
    public class Timeslot
    {
        [Column("TimeslotId")]
        public int Id { get; set; }
        public string Weekday { get; set; }
        [Column("StartTime"),Required]
        public TimeSpan Start { get; set; }
        [Column("EndTime"), Required]
        public TimeSpan End { get; set; }
    }
}
