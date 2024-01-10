using Microsoft.AspNetCore.Components.WebAssembly.Http;
using PersonaliTune.Models;
using PersonaliTune.Models.Prompts;
using PersonaliTune.UI.Models;
using System.Net.Http.Json;

namespace PersonaliTune.UI.Services;

public class OpenAiApiService : IOpenAiApiService
{
    private readonly string _baseUrl;
    private readonly HttpClient _client;

    public OpenAiApiService(HttpClient client)
    {
        //Note: this value, as well as an API key, should be in KeyVault
        _baseUrl = "https://localhost:7002";
        _client = client;
    }

    public async Task<ChatResult> GetRecommendedArtist(ArtistCollection? artists)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(
                $"{_baseUrl}/prompt/artist", artists);
            var content = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode
                ? ChatResult.CreateSuccessResult(content)
                : ChatResult.CreateFailureResult(content);
        }
        catch (Exception ex)
        {
            return ChatResult.CreateFailureResult(ex.Message);
        }
    }

    public async Task<HttpResponseMessage> GetStreamChat(List<Prompt> messages)
    {
        using var req = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/prompt/chat/");
        req.Content = JsonContent.Create(messages);
        req.SetBrowserResponseStreamingEnabled(true);
        var response = await _client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Cannot retrieve chat: " + response.ReasonPhrase);
        }

        return response;
    }

    public async Task<string> GetDefaultSystemMessage()
    {
        var response = await _client.GetAsync($"{_baseUrl}/prompt/defaultsystem");
        if (!response.IsSuccessStatusCode)
        {
            return string.Empty;
        }
        return await response.Content.ReadAsStringAsync();
    }
}
