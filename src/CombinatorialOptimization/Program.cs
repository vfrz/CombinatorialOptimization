using System;

namespace CombinatorialOptimization
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var algorithm = new GeneticAlgorithm
            {
                MaxGeneration = 100,
                Dimension = 10,
                PopulationSize = 30,
                FitnessCalculation = FitnessCalculation
            };
            var result = algorithm.Run();
            Console.WriteLine(result.ToString());
        }

        private static int FitnessCalculation(Individual individual)
        {
            var sum = 0;
            var prod = 1;
            for (var i = 0; i < individual.Chromosome.Length; i++)
            {
                if (individual.Chromosome[i] == 0)
                    sum += i + 1;
                else
                    prod *= i + 1;
            }

            return Math.Abs(sum - 36) + Math.Abs(prod - 360);
        }
    }
}