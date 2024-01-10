using PersonaliTune.AzureOpenAI.Api.Models;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.Services;

public interface IOpenAiService
{
    Task<string> GetChatResponseAsync(Conversation input);
    IAsyncEnumerable<string> GetStreamingChatResponse(Conversation input);
}