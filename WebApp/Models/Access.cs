using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Access")]
    public class Access
    {
        [Column("AccessId")]
        public Guid Id { get; set; }

        [Column("AccessName")]
        public string Name { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }

        public string Url { get; set; }
    }
}
