using PersonaliTune.AzureOpenAI.Api.Models;

namespace PersonaliTune.AzureOpenAI.Api.Extensions
{
    public static class RepetitionBehaviourExtensions
    {
        public static float ToFrequencyPenalty(this RepetitionBehaviour repetition)
        {
            double output = repetition switch
            {
                RepetitionBehaviour.AvoidRepetition => 1.0,
                RepetitionBehaviour.Default => 0.0,
                RepetitionBehaviour.Preferred => -1.0,
                _ => throw new NotImplementedException()
            };
            return (float)output;
        }
    }
}
