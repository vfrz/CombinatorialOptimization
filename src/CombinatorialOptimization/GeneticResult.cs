using System.Text;

namespace CombinatorialOptimization
{
    public class GeneticResult
    {
        public int Generation { get; init; }

        public Individual BestIndividual { get; init; }

        public int BestIndividualFitness { get; init; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Genetic result");
            builder.AppendLine("==============");
            builder.AppendLine($"Fitness: {BestIndividualFitness}");
            builder.AppendLine($"Individual: {BestIndividual}");
            builder.AppendLine($"Generation: {Generation}");
            return builder.ToString();
        }
    }
}