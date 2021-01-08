using System;

namespace CombinatorialOptimization
{
    public sealed class GeneticAlgorithm
    {
        public static readonly Random Random = new();

        public int PopulationSize { get; init; } = 30;

        public int Dimension { get; init; } = 10;

        public int MaxGeneration { get; init; } = 100;

        public double Pc { get; init; } = 0.75d;

        public double Pm { get; init; } = 0.01d;

        public Func<Individual, int> FitnessCalculation { get; init; }

        public GeneticResult Run()
        {
            var bestIndividual = new Individual(Dimension);
            var bestFitness = int.MaxValue;

            var population = new Individual[PopulationSize];

            for (var i = 0; i < population.Length; i++)
            {
                population[i] = new Individual(Dimension);
                population[i].FillGenesWithRandomness();
            }

            var currentGeneration = 0;

            for (var k = 0; k < MaxGeneration; k++)
            {
                currentGeneration++;

                for (var i = 0; i < population.Length / 2; i++)
                {
                    var a = Random.Next(0, population.Length);
                    int b;
                    do
                    {
                        b = Random.Next(0, population.Length);
                    } while (b == a);

                    if (Random.NextDouble() < Pc)
                        Crossover(population, a, b);

                    if (Random.NextDouble() < Pm)
                        Mutation(population, a);

                    if (Random.NextDouble() < Pm)
                        Mutation(population, b);
                }

                for (var i = 0; i < population.Length; i++)
                {
                    var fitness = FitnessCalculation(population[i]);

                    if (fitness < bestFitness)
                    {
                        bestIndividual = population[i].Clone();
                        bestFitness = fitness;
                        
                        if (bestFitness == 0)
                            break;
                    }
                }
                
                if (bestFitness == 0)
                    break;
            }

            return new GeneticResult
            {
                Generation = currentGeneration,
                BestIndividual = bestIndividual,
                BestIndividualFitness = bestFitness
            };
        }

        private void Crossover(Individual[] population, int a, int b)
        {
            var index = Random.Next(0, Dimension);
            
            var aIndividual = population[a].Clone();
            var bIndividual = population[b].Clone();

            for (var i = index; i < Dimension; i++)
            {
                population[a].Chromosome[i] = bIndividual.Chromosome[i];
                population[b].Chromosome[i] = aIndividual.Chromosome[i];
            }
        }

        private void Mutation(Individual[] population, int a)
        {
            for (var i = 0; i < population.Length; i++)
            {
                for (var x = 0; x < Dimension; x++)
                {
                    if (Random.NextDouble() < 1f / Dimension)
                        population[i].Chromosome[x] = population[i].Chromosome[x] == 0 ? 1 : 0;
                }
            }
        }
    }
}