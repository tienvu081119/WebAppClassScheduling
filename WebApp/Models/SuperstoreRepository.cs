using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SuperstoreRepository : BaseRepository
    {
        public SuperstoreRepository(CSContext context) : base(context) { }

        public int Add (List<Superstore> list)
        {
            context.Superstores.AddRange(list);
            return context.SaveChanges();
        }

        public List<Superstore> GetSuperstores(int page, int size, out int total)
        {
            total = (context.Superstores.Count() - 1) / size + 1;
            return context.Superstores.OrderBy(p => p.RowId).Skip((page - 1) * size).Take(size).ToList();
        }

        public List<Superstore> SearchSuperstores(string q, int page, int size, out int total)
        {
            total = (context.Superstores.Where(p => p.CustomerName.Contains(q)).Count() - 1) / size + 1;

            return context.Superstores.Where(p => p.CustomerName.Contains(q)).OrderBy(p => p.RowId).Skip((page - 1) * size).Take(size).ToList();
        }
    }
}
