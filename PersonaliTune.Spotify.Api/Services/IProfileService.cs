namespace PersonaliTune.Spotify.Api.Services;

public interface IProfileService
{
    Task<string> Get(string token);
    Task<string> GetTopArtists(string token);
    Task<string> GetTopTracks(string token);
}
