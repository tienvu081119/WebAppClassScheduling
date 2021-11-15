using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGeneticAlgorithm
{
    // Quần thể
    class Population
    {
        Individual[] population;
        //Tổng số fitness của các cá thể
        //độ thích nghi
        //Tổng độ thích nghi của các cá thể
        double fitness = -1;
        public double Fitness
        {
            get
            {
                return fitness;
            }
        }
        // Số lượng quần thể
        public Population (int size)
        {
            population = new Individual[size];
        }

        public Population(int size, int chromosomeLength)
        {
            population = new Individual[size];
            for(int i = 0; i < size; i++)
            {
                population[i] = new Individual(chromosomeLength);
            }
        }

        //GetIndividual()

        public Individual[] GetIndividuals()
        {
            return population;
        }

        public int GetSize()
        {
            return population.Length;
        }

        public Individual GetIndividual(int offset)
        {
            return population[offset];
        }

        public void SetIndividual(int offset, Individual individual)
        {
            population[offset] = individual;
        }
        //C#

        public Individual[] Individuals
        {
            get { return population; }
        }

        public int Size
        {
            get { return population.Length; }
        }

        //Indexer
        public Individual this[int offset]
        {
            get
            {
                return population[offset];
            }
            set
            {
                population[offset] = value;
            }
        }
    }
}
