using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Student")]
    public class Student
    {
        [Column("StudentId")]
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
