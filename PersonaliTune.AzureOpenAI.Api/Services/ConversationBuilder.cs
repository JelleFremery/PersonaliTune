using PersonaliTune.AzureOpenAI.Api.Models;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.Services;

public class ConversationBuilder
{
    private readonly Conversation _conversation = new()
    {
        Prompts = new List<Prompt> { },
        Randomness = Randomness.Average,
        MaxTokens = 800,
        RepetitionBehaviour = RepetitionBehaviour.Default
    };

    public Conversation Build()
    {
        return _conversation;
    }

    public ConversationBuilder WithPrompts(List<Prompt> messages)
    {
        _conversation.Prompts = messages;
        return this;
    }

    public ConversationBuilder WithRandomness(Randomness randomness)
    {
        _conversation.Randomness = randomness;
        return this;
    }

    public ConversationBuilder WithMaxTokens(int maxTokens)
    {
        _conversation.MaxTokens = maxTokens;
        return this;
    }

    public ConversationBuilder WithRepetitionBehaviour(RepetitionBehaviour repetitionBehaviour)
    {
        _conversation.RepetitionBehaviour = repetitionBehaviour;
        return this;
    }
}
