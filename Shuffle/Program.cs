using System;

namespace Shuffle
{
    class Program
    {
        static void Shuffle(int[] a)
        {
            Random random = new Random();
            for(int i = 2; i < a.Length;i++)
            {
                int j = random.Next(i); // [0,j]
                int t = a[i];
                a[i] = a[j];
                a[j] = t;
            }
        }

        static void Shuffle2(int[] a)
        {
            Random random = new Random();
            for (int i = a.Length -1; i > 1; i--)
            {
                int j = random.Next(i); // [0,j]
                int t = a[i];
                a[i] = a[j];
                a[j] = t;
            }
        }

        static void Main(string[] args)
        {
            // shufle
            int[] a = { 3, 7, 8, 4, 1, 5, 14, 18, 33, 16, 91, 2 };
            Console.WriteLine("Trước khi shuffle");
            Console.WriteLine(string.Join(",", a));
            Console.WriteLine("Sau khi shuffle");
            Shuffle2(a);
            Console.WriteLine(string.Join(",", a));         
        }
    }
}
