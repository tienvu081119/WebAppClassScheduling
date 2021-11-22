using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class WardRepository : BaseRepository
    {
        public WardRepository(CSContext context) : base(context) { }

        public List<Ward> GetWardsByDistrict(string id)
        {
            return context.Wards.Where(p=>p.DistrictId == id).ToList();
        }

        public List<Ward> GetWards(int page, int size, out int total)
        {
            total = (context.Wards.Count() - 1) / size + 1;
            return context.Wards.OrderBy(p => p.Id).Skip((page - 1) * size).Take(size).ToList();
        }
    }
}
