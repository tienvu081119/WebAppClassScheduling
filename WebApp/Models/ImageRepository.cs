using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ImageRepository : BaseRepository
    {
        public ImageRepository(CSContext context) : base(context) { }

    


        public List<Image> GetImages()
        {
            return context.Images.ToList();
        }

        public int Add(Image obj)
        {
            context.Images.Add(obj);
            return context.SaveChanges();
        }

        public int Add(List<Image> list)
        {
            context.Images.AddRange(list);
            return context.SaveChanges();
        }
    }
}
