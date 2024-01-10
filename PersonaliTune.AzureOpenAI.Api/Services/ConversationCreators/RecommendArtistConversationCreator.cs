using PersonaliTune.AzureOpenAI.Api.Models;
using PersonaliTune.AzureOpenAI.Api.PromptTemplates.NewArtistRecommendation;
using PersonaliTune.Models;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.Services.ConversationCreators;

public class RecommendArtistConversationCreator : IConversationCreator<ArtistCollection>
{
    private readonly IPromptFactory _promptFactory;

    public RecommendArtistConversationCreator(
        IPromptFactory promptFactory)
    {
        _promptFactory = promptFactory;
    }

    public Conversation Create(ArtistCollection? data)
    {
        var messages = GetMessages(data);
        return new ConversationBuilder()
                .WithPrompts(messages)
                .WithRandomness(Randomness.Low)
                .WithMaxTokens(1000)
                .Build();
    }

    private List<Prompt> GetMessages(ArtistCollection? data)
    {
        List<Prompt> prompts;
        if (data?.items == null || data.items.Count == 0)
        {
            prompts = _promptFactory.Create(
                new NewArtistRecommendationSystemTemplate(),
                new RandomArtistRecommendationUserTemplate());
        }
        else
        {
            prompts = _promptFactory.Create(
                new NewArtistRecommendationSystemTemplate(),
                new NewArtistRecommendationUserTemplate(data));
        }
        return prompts;
    }
}
