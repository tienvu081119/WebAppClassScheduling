using System;
using System.Collections.Generic;
using System.Text;

namespace Sorted
{
    // 2 cách kế thừa Interface
    class Student :  IComparable<Student>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public decimal GPA { get; set; }

        public int CompareTo(Student other)
        {
            // Sấp xếp theo Id 
            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"id:{Id}, fullname:{FullName}, GPA: {GPA}";
        }
    }
}
