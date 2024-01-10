using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.PromptTemplates.NewArtistRecommendation;

public class NewArtistRecommendationSystemTemplate : IPromptTemplate
{
    public string GetPromptRole() => PromptRole.System;

    public string GetPromptMessage() =>
        @"You are an AI assistant that helps people find music similar to their taste."
        + @" Please start your answer as a separate statement, not a reply.";
}
