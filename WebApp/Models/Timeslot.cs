using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Timeslot")]
    public class Timeslot
    {
        [Column("TimeslotId")]
        public int Id { get; set; }
        public string Weekday { get; set; }
        [Column("StartTime")]
        public TimeSpan Start { get; set; }
        [Column("EndTime")]
        public TimeSpan End { get; set; }
    }
}
