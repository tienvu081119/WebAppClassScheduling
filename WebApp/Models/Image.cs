using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Table("Image")]
    public class Image
    {
        [Column("ImageId")]

        public Guid Id { get; set; }

        [Column("ImageOriginal")]

        public string Original { get; set; }

        [Column("ImageUrl")]

        public string Url { get; set; }

        [Column("ImageType")]
        public string Type { get; set; }

        [Column("ImageSize")]
        public long Size { get; set; }
    }
}
