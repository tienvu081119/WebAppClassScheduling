using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ModuleProfessorRepository : BaseRepository
    {
        public ModuleProfessorRepository(CSContext context) : base(context)
        {

        }

        public List<ModuleProfessor> GetModuleProfessorsByModule(int id)
        {
            return context.ModuleProfessors.Where(p => p.ModuleId == id).ToList();
        }

        public int Add(List<ModuleProfessor> list)
        {
            context.ModuleProfessors.AddRange(list);
            return context.SaveChanges();
        }
    }
}
