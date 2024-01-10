using PersonaliTune.Models;

namespace PersonaliTune.UI.Services;

public interface ISpotifyApiService
{
    Task<AlbumCollection?> GetAlbumCollection(string id);
    Task<Artist?> GetArtist(string id);
    Task<string?> GetLoginUrl();
    Task<SpotifyDto?> GetNewReleases();
    Task<Profile?> GetProfile(string token);
    Task<string?> GetToken(string code);
    Task<ArtistCollection?> GetTopArtists(string token);
    Task<TrackCollection?> GetTopTracks(string token);
    Task<SpotifyDto?> Search(string query);
}