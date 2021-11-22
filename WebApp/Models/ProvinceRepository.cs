using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProvinceRepository : BaseRepository
    {
        public ProvinceRepository(CSContext context) : base(context) { }
        
        public List<Province> GetProvinces()
        {
            return context.Provinces.ToList();
        }
    }
}
