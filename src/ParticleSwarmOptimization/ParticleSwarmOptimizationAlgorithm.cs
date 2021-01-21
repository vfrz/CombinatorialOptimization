using System;
using System.Linq;

namespace ParticleSwarmOptimization
{
    public class ParticleSwarmOptimizationAlgorithm
    {
        private readonly Random _random;

        public int ParticleCount { get; set; } = 40;

        public int NeighborCount { get; set; } = 4;

        public int MaxIteration { get; set; } = 10000;

        public float DeltaMinSpeed { get; set; } = -4.0f;

        public float DeltaMaxSpeed { get; set; } = 4.0f;

        public float TargetFitness { get; set; } = 0f;

        public int SpaceDimension { get; set; } = 4;

        public float MinValue { get; set; } = -5.12f;

        public float MaxValue { get; set; } = 5.12f;

        public int C1 { get; set; } = 2;

        public int C2 { get; set; } = 2;

        public Func<Particle, ParticleSwarmOptimizationAlgorithm, float> FitnessCalculation { get; set; }

        public Particle[] Particles { get; private set; }

        public ParticleSwarmOptimizationAlgorithm()
        {
            _random = new Random();
        }

        public void Initialize()
        {
            Particles = new Particle[ParticleCount];

            for (var i = 0; i < Particles.Length; i++)
            {
                Particles[i] = new Particle(SpaceDimension);

                for (var d = 0; d < SpaceDimension; d++)
                {
                    Particles[i].CurrentPosition[d] = _random.NextFloat(MinValue, MaxValue);
                    Particles[i].BestPosition[d] = Particles[i].CurrentPosition[d];
                    Particles[i].Speed[d] = _random.NextFloat(DeltaMinSpeed, DeltaMaxSpeed);
                }

                Particles[i].CurrentFitness = FitnessCalculation(Particles[i], this);
                Particles[i].BestFitness = Particles[i].CurrentFitness;
            }
        }

        public Particle Run()
        {
            var iteration = 1;
            var stop = false;
            var bestParticle = default(Particle);

            while (iteration <= MaxIteration && !stop)
            {
                for (var i = 0; i < ParticleCount; i++)
                {
                    var particle = Particles[i];
                    var bestNeighbor = GetBestNeighbor(particle);
                    for (var d = 0; d < SpaceDimension; d++)
                    {
                        var r1 = C1 * (float) _random.NextDouble();
                        var r2 = C2 * (float) _random.NextDouble();

                        var speed = particle.Speed[d]
                            + r1 * (particle.BestPosition[d] - particle.CurrentPosition[d])
                            + r2 * (bestNeighbor.BestPosition[d] - particle.CurrentPosition[d]);
                        particle.Speed[d] = Math.Clamp(speed, DeltaMinSpeed, DeltaMaxSpeed);

                        var position = particle.CurrentPosition[d] + particle.Speed[d];
                        particle.CurrentPosition[d] = Math.Clamp(position, MinValue, MaxValue);
                    }
                }

                for (var i = 0; i < ParticleCount; i++)
                {
                    var particle = Particles[i];
                    var fitness = FitnessCalculation(particle, this);
                    if (fitness < particle.BestFitness)
                    {
                        particle.BestFitness = fitness;
                        for (var d = 0; d < SpaceDimension; d++)
                        {
                            particle.BestPosition[d] = particle.CurrentPosition[d];
                        }
                    }

                    if (particle.BestFitness < (bestParticle?.BestFitness ?? float.MaxValue))
                    {
                        bestParticle = particle;
                    }

                    if (fitness == TargetFitness)
                    {
                        stop = true;
                    }
                }

                iteration++;
            }

            return bestParticle;
        }

        public Particle GetBestNeighbor(Particle particle)
        {
            var bestNeighbor = Particles
                .Where(p => p != particle)
                .OrderBy(p => DistanceBetweenParticles(p, particle))
                .First();

            return bestNeighbor;
        }

        private float DistanceBetweenParticles(Particle particle1, Particle particle2)
        {
            var distance = 0f;
            for (var i = 0; i < SpaceDimension; i++)
                distance += Math.Abs(particle1.CurrentPosition[i] - particle2.CurrentPosition[i]);
            return distance;
        }
    }
}