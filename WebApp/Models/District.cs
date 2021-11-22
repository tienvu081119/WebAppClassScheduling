using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("District")]
    public class District
    {
        [Column("DistrictId")]
        public string Id { get; set;}

        public string ProvinceId { get; set; }

        [Column("DistrictName")]
        public string Name { get; set; }
    }
}
