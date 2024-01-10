using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using PersonaliTune.AzureOpenAI.Api.Extensions;
using PersonaliTune.AzureOpenAI.Api.Models;

namespace PersonaliTune.AzureOpenAI.Api.Services;

public class OpenAiService : IOpenAiService
{
    private readonly string _deploymentName;
    private readonly OpenAIClient _client;

    public OpenAiService(IOptions<AzureOpenAiOptions> options)
    {
        if (options?.Value?.DeploymentName == null || options.Value.Endpoint == null || options.Value.Key == null)
        {
            throw new ArgumentException("AzureOpenAiOptions must have DeploymentName, Endpoint and Key set.", nameof(options));
        }

        _deploymentName = options.Value.DeploymentName;
        _client = new OpenAIClient(
            new Uri(options.Value.Endpoint),
            new AzureKeyCredential(options.Value.Key));
    }

    public async Task<string> GetChatResponseAsync(Conversation input)
    {
        try
        {
            var options = GetChatCompletionsOptions(input);
            var response = await _client.GetChatCompletionsAsync(options);
            return response.Value.Choices[0].Message.Content;
        }
        catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException)
        {
            return ex.Message;
        }
        catch (Exception)
        {
            return "The AI assistant did not respond due to an error. Please retry later.";
        }
    }

    public async IAsyncEnumerable<string> GetStreamingChatResponse(Conversation input)
    {
        var options = GetChatCompletionsOptions(input);
        var response = await _client.GetChatCompletionsStreamingAsync(options);

        await foreach (var value in response.EnumerateValues())
        {
            if (value.ChoiceIndex == 0)
            {
                yield return value.ContentUpdate;
            }
        }
    }

    private ChatCompletionsOptions GetChatCompletionsOptions(Conversation conversation)
    {
        var prompts = conversation.Prompts?.ToChatRequestMessages();

        return new ChatCompletionsOptions(_deploymentName, prompts)
        {
            Temperature = conversation.Randomness.ToTemperature(),
            MaxTokens = conversation.MaxTokens,
            NucleusSamplingFactor = (float)0.95,
            FrequencyPenalty = conversation.RepetitionBehaviour.ToFrequencyPenalty(),
            PresencePenalty = 0,
        };
    }
}