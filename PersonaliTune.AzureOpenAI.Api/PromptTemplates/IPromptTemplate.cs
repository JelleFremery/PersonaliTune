namespace PersonaliTune.AzureOpenAI.Api.PromptTemplates;

public interface IPromptTemplate
{
    string GetPromptRole();
    string GetPromptMessage();
}
