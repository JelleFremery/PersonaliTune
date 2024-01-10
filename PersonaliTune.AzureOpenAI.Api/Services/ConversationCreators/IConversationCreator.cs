using PersonaliTune.AzureOpenAI.Api.Models;

namespace PersonaliTune.AzureOpenAI.Api.Services.ConversationCreators;

public interface IConversationCreator<in T>
{
    Conversation Create(T? data);
}