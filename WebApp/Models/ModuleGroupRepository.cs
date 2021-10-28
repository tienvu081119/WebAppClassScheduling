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

        public List<ModuleGroup> GetModuleGroupsByGroup(int id)
        {
            return context.ModuleGroups.Where(p => p.GroupId == id).ToList();
        }

        
    }
}
