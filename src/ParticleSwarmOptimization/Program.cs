using System;
using System.Linq;

namespace ParticleSwarmOptimization
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var algorithm = new ParticleSwarmOptimizationAlgorithm
            {
                FitnessCalculation = FitnessCalculation
            };
            algorithm.Initialize();
            var bestParticle = algorithm.Run();
            Console.WriteLine(bestParticle.ToString());
        }

        private static float FitnessCalculation(Particle particle, ParticleSwarmOptimizationAlgorithm algorithm)
        {
            var result = 10 * algorithm.SpaceDimension
                + particle.CurrentPosition.Sum(xi => Math.Pow(xi, 2) - 10 * Math.Cos(2 * Math.PI * xi));
            return (float) result;
        }
    }
}