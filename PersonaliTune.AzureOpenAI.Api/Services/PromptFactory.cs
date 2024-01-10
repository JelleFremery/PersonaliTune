using PersonaliTune.AzureOpenAI.Api.PromptTemplates;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.Services;

public class PromptFactory : IPromptFactory
{
    public Prompt Create(IPromptTemplate promptTemplate)
        => Prompt.Create(promptTemplate.GetPromptRole(), promptTemplate.GetPromptMessage());

    public List<Prompt> Create(params IPromptTemplate[] promptTemplates)
        => promptTemplates.Select(Create).ToList();
}
