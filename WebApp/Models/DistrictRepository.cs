using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DistrictRepository : BaseRepository
    {
        public DistrictRepository(CSContext context) : base(context) { }

        public List<District> GetDistrictsByProvince(string id)
        {
            return context.Districts.Where(p => p.ProvinceId == id).ToList();
        }
    }
}
