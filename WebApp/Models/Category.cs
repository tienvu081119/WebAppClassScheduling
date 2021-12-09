using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Category")]
    public class Category
    {

        [Column("CategoryId")]
        public int Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]

        public List<Category> Children { get; set; }
    }
}
