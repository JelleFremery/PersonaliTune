using PersonaliTune.AzureOpenAI.Api.PromptTemplates;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.Services;

public interface IPromptFactory
{
    public Prompt Create(IPromptTemplate promptTemplate);
    public List<Prompt> Create(params IPromptTemplate[] promptTemplates);
}
