using System;

namespace RouletteWheelSelection
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] roulette = { 3.5, 7.8, 9.6, 7.2, 9.5, 11,2,49.5 };
            Random random = new Random();
            double s = 0;
            foreach(double item in roulette)
            {
                s += item;
            }
            Console.WriteLine($"Total:{s}");
            double t = s * random.NextDouble();
            Console.WriteLine(t);
            s = 0;
            Console.WriteLine(string.Join(",", roulette));
            for(int i = 0; i < roulette.Length; i++)
            {
                s += roulette[i];
                if(s >= t)
                {
                    // Phần tử được chọn
                    Console.WriteLine(roulette[i]);
                    break;
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
