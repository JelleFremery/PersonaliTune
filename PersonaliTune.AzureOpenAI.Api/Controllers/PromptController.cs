using Microsoft.AspNetCore.Mvc;
using PersonaliTune.AzureOpenAI.Api.PromptTemplates;
using PersonaliTune.AzureOpenAI.Api.Services;
using PersonaliTune.AzureOpenAI.Api.Services.ConversationCreators;
using PersonaliTune.Models;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.Spotify.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PromptController : ControllerBase
{
    private readonly IPromptFactory _promptFactory;
    private readonly IOpenAiService _openAiService;

    public PromptController(IPromptFactory promptFactory, IOpenAiService openAiService)
    {
        _promptFactory = promptFactory;
        _openAiService = openAiService;
    }

    [HttpPost]
    [Route("chat")]
    public IAsyncEnumerable<string> StreamingChat(List<Prompt> prompts)
    {
        var conversation = new ConversationBuilder().WithPrompts(prompts).Build();
        return _openAiService.GetStreamingChatResponse(conversation);
    }

    [HttpPost]
    [Route("artist")]
    public async Task<string> RecommendArtist(ArtistCollection model)
    {
        var convoCreator = new RecommendArtistConversationCreator(_promptFactory);
        var conversation = convoCreator.Create(model);
        return await _openAiService.GetChatResponseAsync(conversation);
    }

    [HttpGet]
    [Route("defaultsystem")]
    public string GetDefaultSystemMessage()
    {
        return new DefaultSystemTemplate().GetPromptMessage();
    }
}

