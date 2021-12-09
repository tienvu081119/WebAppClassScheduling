using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(CSContext context) : base(context)
        {

        }

        public List<Category> GetParents()
        {
            return context.Categories.Where(p => p.ParentId == null).Include(p => p.Children).ToList();
        }

        public int Edit(Category obj)
        {
            context.Categories.Update(obj);
            return context.SaveChanges();
        }

        public int Add(Category obj)
        {
            context.Categories.Add(obj);
            return context.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            return context.Categories.Select(p=> new Category { Id = p.Id, Name = p.Name, ParentId = p.ParentId }).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return context.Categories.Find(id);
        }

        
    }
}
