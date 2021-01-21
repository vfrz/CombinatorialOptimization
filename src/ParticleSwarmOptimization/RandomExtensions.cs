using System;

namespace ParticleSwarmOptimization
{
    public static class RandomExtensions
    {
        public static float NextFloat(this Random random, float min, float max)
        {
            var value = random.NextDouble() * (max - min) + min;
            return (float) value;
        }
    }
}