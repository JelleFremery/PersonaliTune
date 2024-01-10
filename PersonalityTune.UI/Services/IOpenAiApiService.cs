using PersonaliTune.Models;
using PersonaliTune.Models.Prompts;
using PersonaliTune.UI.Models;

namespace PersonaliTune.UI.Services
{
    public interface IOpenAiApiService
    {
        Task<ChatResult> GetRecommendedArtist(ArtistCollection artists);
        Task<HttpResponseMessage> GetStreamChat(List<Prompt> messages);
        Task<string> GetDefaultSystemMessage();
    }
}
