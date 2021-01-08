using System;

namespace CombinatorialOptimization
{
    public sealed class Individual
    {
        public byte[] Chromosome { get; }

        public Individual(int dimension = 10)
        {
            Chromosome = new byte[dimension];
        }

        public Individual(byte[] chromosome)
        {
            Chromosome = chromosome;
        }

        public void FillGenesWithRandomness()
        {
            for (var i = 0; i < Chromosome.Length; i++)
            {
                Chromosome[i] = (byte) GeneticAlgorithm.Random.Next(0, 2);
            }
        }

        public static void PrintPopulation(Individual[] population)
        {
            for (var i = 0; i < population.Length; i++)
            {
                Console.WriteLine($"{i}: {population[i]}");
            }
        }

        public Individual Clone()
        {
            return new Individual(Chromosome);
        }
        
        public override string ToString()
        {
            return $"|{string.Join('|', Chromosome)}|";
        }
    }
}