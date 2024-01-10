namespace PersonaliTune.Spotify.Api.Services;

public class ProfileService : IProfileService
{
    private readonly ISpotifyService _spotifyService;
    public ProfileService(ISpotifyService spotifyService)
    {
        _spotifyService = spotifyService;
    }

    public async Task<string> Get(string token)
    {
        string endpoint = "me";
        var response = await _spotifyService.GetPrivateContentAsync(token, endpoint);
        return response.ToString();
    }
    public async Task<string> GetTopArtists(string token)
    {
        string endpoint = "me/top/artists";
        var response = await _spotifyService.GetPrivateContentAsync(token, endpoint);
        return response.ToString();
    }

    public async Task<string> GetTopTracks(string token)
    {
        string endpoint = "me/top/tracks";
        var response = await _spotifyService.GetPrivateContentAsync(token, endpoint);
        return response.ToString();
    }
}
