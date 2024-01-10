using Azure.AI.OpenAI;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.Extensions;

public static class PromptExtensions
{
    public static List<ChatRequestMessage> ToChatRequestMessages(this List<Prompt> prompts)
    {
        return prompts.Select(prompt => prompt.ToChatRequestMessage()).ToList();
    }

    public static ChatRequestMessage ToChatRequestMessage(this Prompt prompt)
    {
        return prompt.Role switch
        {
            PromptRole.User => new ChatRequestUserMessage(prompt.Content),
            PromptRole.System => new ChatRequestSystemMessage(prompt.Content),
            PromptRole.Assistant => new ChatRequestAssistantMessage(prompt.Content),
            _ => throw new ArgumentException("Message must contain roles only of an acceptable value.", nameof(prompt))
        };
    }
}
