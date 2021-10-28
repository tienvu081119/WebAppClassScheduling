using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class GroupRepository : BaseRepository
    {
        public GroupRepository(CSContext context) : base(context) { }

        public List<Group> GetGroups()
        {
            return context.Groups.ToList();
        }

        public int Add(Group obj)
        {
            context.Groups.Add(obj);
            return context.SaveChanges();
        }

        public Group GetGroupById(int id)
        {
            return context.Groups.Find(id);
        }

        public Group GetGroupAndModules(int id)
        {
            return context.Groups.Include(p => p.ModuleGroups).FirstOrDefault<Group>(p => p.Id == id);
        }
    }
}
