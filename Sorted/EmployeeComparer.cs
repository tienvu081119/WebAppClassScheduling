using System;
using System.Collections.Generic;
using System.Text;

namespace Sorted
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Fullname.CompareTo(y.Fullname);
        }
    }
}
