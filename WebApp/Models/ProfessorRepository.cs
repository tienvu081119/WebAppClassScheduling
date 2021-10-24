using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProfessorRepository
    {
        CSContext context;
        public ProfessorRepository(CSContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            context.Professors.Remove(new Professor { Id = id });
            return context.SaveChanges();
        }

        public List<Professor> GetProfessors()
        {
            return context.Professors.ToList();
        }

        //public int Add(Professor obj)
        //{
        //    context.Professors.Add(obj);
        //    return context.SaveChanges();
        //}

        public async Task<int> Add(Professor obj)
        {
            context.Professors.Add(obj);
            return await context.SaveChangesAsync();
        }
    }
}
