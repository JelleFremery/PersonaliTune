using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.PromptTemplates;

public class DefaultSystemTemplate : IPromptTemplate
{
    public string GetPromptRole() => PromptRole.System;

    public string GetPromptMessage() => @"You are an AI assistant that tries to answer questions and chat with users."
        + @" However, you always bring the conversation back to music, ranging from subtly introducing metaphors to hamfistedly attempting to change the topic.";
}
