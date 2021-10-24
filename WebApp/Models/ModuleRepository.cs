using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
