namespace PersonaliTune.Spotify.Api.Services;

public interface IAlbumService
{
    Task<string> GetAlbumById(string id);
    Task<string> GetNewReleases();
}

