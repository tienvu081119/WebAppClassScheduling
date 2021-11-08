using System;
using System.Collections.Generic;

namespace Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Binh", "Tan", "An", "Thai", "Trong","Vu","Lan" };
            Console.WriteLine(string.Join(",", arr));
            Array.Sort(arr);
            Console.WriteLine(string.Join(",", arr));
            List<string> list = new List<string>
            {
                "Binh", "Tan", "An", "Thai", "Trong","Vu","Lan"
            };

            Console.WriteLine("Truoc khi sap xep");
            Console.WriteLine(string.Join(",",list));
            list.Sort();
            Console.WriteLine("Sau khi sap xep");
            Console.WriteLine(string.Join(",", list));

            Student[] students = {
                new Student{ Id = 33, FullName = "Tien",GPA = 7.6m },
                new Student{ Id = 34, FullName = "An",GPA = 8.3m },
                new Student{ Id = 12, FullName = "Sinh",GPA = 9.8m },
                new Student{ Id = 15, FullName = "Teo",GPA = 6.2m },
            };

            Console.WriteLine("Truoc khi sap xep");
            foreach(var item in students)
            {
                Console.WriteLine(item);
            }

            Array.Sort(students);
            Console.WriteLine("Sau khi sap xep");
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Employee[] employees =
            {
                new Employee {Id = 33, Fullname = "Tien", Salary = 7.6m },
                new Employee {Id = 44, Fullname = "An", Salary = 8.3m },
                new Employee {Id = 12, Fullname = "Sinh", Salary = 9.8m },
                new Employee {Id = 15, Fullname = "Teo", Salary = 6.2m },
            };

            Console.WriteLine("Truoc khi sap xep");
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }

            Array.Sort(employees, new EmployeeComparer());
            Console.WriteLine("Sau khi sap xep");
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }
    }
}
