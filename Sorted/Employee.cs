using System;
using System.Collections.Generic;
using System.Text;

namespace Sorted
{
    class Employee
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"id:{Id}, fullname:{Fullname}, Salary:{Salary}";
        }
    }
}
