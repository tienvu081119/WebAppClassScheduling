using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private CSContext context;
        private GenericRepository<Student> student;    
        public UnitOfWork(CSContext context)
        {
            this.context = context;
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                return student ?? (student = new GenericRepository<Student>(context));
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
