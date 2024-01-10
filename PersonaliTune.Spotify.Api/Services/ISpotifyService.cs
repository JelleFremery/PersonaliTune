namespace PersonaliTune.Spotify.Api.Services;

public interface ISpotifyService
{
    Task<string> GetPrivateContentAsync(string code, string endpoint);
    Task<string> GetPublicContentAsync(string endpoint);
    string GetLoginUrl();
    Task<string> GetToken(string code);
}

