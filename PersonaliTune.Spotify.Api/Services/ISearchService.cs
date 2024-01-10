namespace PersonaliTune.Spotify.Api.Services;

public interface ISearchService
{
    Task<string> SearchArtistOrAlbumOrTrack(string query);
}

