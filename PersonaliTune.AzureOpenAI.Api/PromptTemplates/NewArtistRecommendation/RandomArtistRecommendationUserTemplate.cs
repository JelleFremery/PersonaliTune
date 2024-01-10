using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.PromptTemplates.NewArtistRecommendation;

public class RandomArtistRecommendationUserTemplate : IPromptTemplate
{
    public string GetPromptRole() => PromptRole.User;

    public string GetPromptMessage()
    {
        return @"Can you recommend me a random artist?"
            + @" Please give a brief overview of the artist and a few reasons why people generally like the artist."
            + @" Your answer should be around 500 words long.";
    }
}
