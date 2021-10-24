using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CSContext : DbContext
    {
        public CSContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<ModuleProfessor> ModuleProfessors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModuleProfessor>().HasKey(p => new { p.ModuleId, p.ProfessorId });

        }

    }
}
