using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Province")]
    public class Province
    {
        [Column("ProvinceId")]
        public string Id { get; set; }

        [Column("ProvinceName")]

        public string Name { get; set; }
    }
}
