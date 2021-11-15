using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGeneticAlgorithm
{
    // 1 cá thể
    class Individual
    {
        // Nhiễm sắc thể (chuỗi gene)
        int[] chromosome;
        // Độ thích nghi (max = 1)
        //[0 =>1]
        double fitness = -1;
        public double Fitness
        {
            get
            {
                return fitness;
            }
        }

        Random random = new Random();
        public Individual(int[] chromosome)
        {
            this.chromosome = chromosome;
        }

        public Individual(int length)
        {
            chromosome = new int[length];
            for(int i = 0; i < length; i++)
            {
                //if(random.NextDouble() > 0.5)
                //{
                //    chromosome[i] = 0;
                //}
                //else
                //{
                //    chromosome[i] = 1;
                //}

                chromosome[i] = random.Next() % 2;
            }
        }
        //Indexer
        public void setGene(int offset, int val)
        {
            chromosome[offset] = val;
        }

        public int GetGene(int offset)
        {
            return chromosome[offset];
        }

        //Indexer == Properties

        public int this[int offset]
        {
            get
            {
                return chromosome[offset];
            }
            set
            {
                chromosome[offset] = value;
            }
        }

        public override string ToString()
        {
            return string.Join("", chromosome);
        }
    }
}
