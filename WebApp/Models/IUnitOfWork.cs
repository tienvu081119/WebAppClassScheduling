using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface IUnitOfWork
    {
        GenericRepository<Student> StudentRepository { get; }
        void Commit();
    }
}
