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
        public DbSet<ProfessorChecked> professorCheckeds { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ModuleGroup> ModuleGroups { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MemberInRole> MemberInRoles { get; set; }        
        public DbSet<RoleChecked> RoleCheckeds { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Access> Accesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MemberInRole>().HasKey(p => new { p.MemberId, p.RoleId });

            modelBuilder.Entity<ModuleProfessor>().HasKey(p => new { p.ModuleId, p.ProfessorId });
            modelBuilder.Entity<ModuleProfessor>()
                .HasOne(mp => mp.Module)
                .WithMany(m => m.ModuleProfessors)
                .HasForeignKey(mp => mp.ModuleId);
            modelBuilder.Entity<ModuleProfessor>()
                .HasOne(mp => mp.Professor)
                .WithMany(p => p.ModuleProfessors)
                .HasForeignKey(mp => mp.ProfessorId);

            modelBuilder.Entity<ModuleGroup>().HasKey(p => new { p.ModuleId, p.GroupId });
            modelBuilder.Entity<ModuleGroup>()
                .HasOne(mg => mg.Module)
                .WithMany(m => m.ModuleGroups)
                .HasForeignKey(mg => mg.ModuleId);
            modelBuilder.Entity<ModuleGroup>()
                .HasOne(mg => mg.Group)
                .WithMany(g => g.ModuleGroups)
                .HasForeignKey(mg => mg.GroupId);


        }

    }
}
