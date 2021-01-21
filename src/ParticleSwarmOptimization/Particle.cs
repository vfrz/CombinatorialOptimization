using System.Text;

namespace ParticleSwarmOptimization
{
    public class Particle
    {
        private readonly int _spaceDimension;
        
        public float[] CurrentPosition { get; set; }
        
        public float[] BestPosition { get; set; }
        
        public float[] Speed { get; set; }
        
        public float CurrentFitness { get; set; }
        
        public float BestFitness { get; set; }
        
        public Particle(int spaceDimension)
        {
            _spaceDimension = spaceDimension;
            CurrentPosition = new float[spaceDimension];
            BestPosition = new float[spaceDimension];
            Speed = new float[spaceDimension];
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{nameof(BestFitness)}: {BestFitness}");
            builder.AppendLine($"{nameof(CurrentFitness)}: {CurrentFitness}");
            builder.AppendLine($"{nameof(BestPosition)}: {string.Join(";", BestPosition)}");
            builder.AppendLine($"{nameof(CurrentPosition)}: {string.Join(";", CurrentPosition)}");
            builder.AppendLine($"{nameof(Speed)}: {string.Join(";", Speed)}");
            
            return builder.ToString();
        }
    }
}