using PersonaliTune.AzureOpenAI.Api.Models;

namespace PersonaliTune.AzureOpenAI.Api.Extensions;

public static class RandomnessExtensions
{
    public static float ToTemperature(this Randomness randomness)
    {
        double output = randomness switch
        {
            Randomness.Deterministic => 0.0,
            Randomness.Low => 0.7,
            Randomness.Average => 1.0,
            Randomness.High => 1.3,
            Randomness.Extreme => 2.0,
            _ => throw new NotImplementedException(),
        };

        return (float)output;
    }
}
