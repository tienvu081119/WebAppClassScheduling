using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ModuleGroupRepository : BaseRepository
    {
        public ModuleGroupRepository(CSContext context) : base(context)
        {

        }

        public List<ModuleGroup> GetModuleGroups()
        {
            return context.ModuleGroups.Include(p=>p.Module).Include(p=>p.Group).ToList();
        }

        public int Add(List<ModuleGroup> list)
        {
            context.ModuleGroups.AddRange(list);
            return context.SaveChanges();
        }

        public int Add(string path)
        {
            string sql = $"BULK INSERT ModuleGroup FROM '{path}' WITH(FORMAT = 'csv', FIRSTROW = 2, FIELDTERMINATOR = ',', ROWTERMINATOR = '0x0A');";
            return context.Database.ExecuteSqlRaw(sql);
        }

        public List<ModuleGroup> GetModuleGroupsByGroup(int id)
        {
            return context.ModuleGroups.Where(p => p.GroupId == id).ToList();
        }

        
    }
}
