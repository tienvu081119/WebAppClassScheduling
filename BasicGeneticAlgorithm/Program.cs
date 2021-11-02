using System;

namespace BasicGeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Individual individual = new Individual(10);
            Console.WriteLine(individual);

            individual.setGene(3, 1);
            Console.WriteLine(individual.GetGene(4));

            //gan giống array
            //Indexer (hay C# sau java)
            individual[5] = 1;
            Console.WriteLine(individual[7]);

            //Pythpn dictionary, set
            Population population = new Population(100, 20);
            Console.WriteLine(population.Size);
            Console.WriteLine(population[0]);
            population[3] = new Individual(7);
        }
    }
}
