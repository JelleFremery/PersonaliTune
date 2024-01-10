using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.Models;

public class Conversation
{
    public List<Prompt>? Prompts { get; internal set; }

    public Randomness Randomness { get; internal set; }

    public int MaxTokens { get; internal set; }

    public RepetitionBehaviour RepetitionBehaviour { get; internal set; }
}
