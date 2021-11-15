using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGeneticAlgorithm
{
    class GeneticAlgorithm
    {
        Random random = new Random();
        public Individual SelectParent(Population population)
        {
            double fitness = population.Fitness;
            double t = fitness * random.NextDouble();
            double s = 0;
            foreach(Individual item in population.Individuals)
            {
                s += item.Fitness;
                if(s >t)
                {
                    return item;
                }
            }
            return population.Individuals[population.Size - 1];
        }
    }
}
