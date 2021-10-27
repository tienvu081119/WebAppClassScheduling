using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class ModuleRepository : BaseRepository
    {
       
        public ModuleRepository(CSContext context) : base(context) { }

        public List<Module> GetModules()
        {
            return context.Modules.ToList();
        }

        public int Add(Module obj)
        {
            context.Modules.Add(obj);
            return context.SaveChanges();
        }

        public Module GetModuleById(int id)
        {
            return context.Modules.Find(id);
        }

        public Module GetModuleAndProfessors(int id)
        {
            return context.Modules.Include(p => p.ModuleProfessors).FirstOrDefault<Module>(p => p.Id == id);
        }
    }
}
