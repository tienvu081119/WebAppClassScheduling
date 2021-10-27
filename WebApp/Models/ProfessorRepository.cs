using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace WebApp.Models
{
    public class ProfessorRepository
    {
        CSContext context;
        public ProfessorRepository(CSContext context)
        {
            this.context = context;
        }

        public List<ProfessorChecked> GetProfessorCheckeds(int id)
        {
            return context.professorCheckeds.FromSqlRaw("EXEC GetProfessorsChecked @Id", new SqlParameter("@Id", id)).ToList();
        }

        public List<Professor> GetProfessorsByModuleId(int id)
        {
            return context.Professors.FromSqlRaw("EXEC GetProfessorsByModuleId @Id", new SqlParameter("@Id", id)).ToList();
        }

        public List<Professor> GetProfessorsNotInModule(int id)
        {
            return context.Professors.FromSqlRaw("EXEC GetProfessorsNotInModule @Id", new SqlParameter("@Id", id)).ToList();
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
