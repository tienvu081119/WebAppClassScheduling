using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Ward")]
    public class Ward
    {
        [Column("WardId")]

        public string Id { get; set; }

        [Column("WardName")]

        public string Name { get; set; }

        public string DistrictId { get; set; }
    }
}
