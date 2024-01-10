using PersonaliTune.Models;
using System.Text.Json;
using Artist = PersonaliTune.Models.Artist;
using Profile = PersonaliTune.Models.Profile;

namespace PersonaliTune.UI.Services;

public class SpotifyApiService : ISpotifyApiService
{
    private readonly string _baseUrl;
    private readonly HttpClient _client;

    public SpotifyApiService(HttpClient client)
    {
        //Note: this value, as well as an API key, should be in KeyVault
        _baseUrl = "https://localhost:7001";
        _client = client;
    }

    public async Task<string?> GetLoginUrl()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/Token/login");
        var response = await _client.SendAsync(request);

        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Cannot determine login url: " + content);
        }
        return content;
    }

    public async Task<string?> GetToken(string code)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/Token/get/{code}");
        var response = await _client.SendAsync(request);

        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Cannot retrieve token: " + content);
        }
        return content;
    }

    public async Task<Artist?> GetArtist(string id)
    {
        return await Get<Artist>($"/artist/{id}");
    }

    public async Task<AlbumCollection?> GetAlbumCollection(string id)
    {
        return await Get<AlbumCollection>($"/artist/{id}/albums");
    }

    public async Task<SpotifyDto?> GetNewReleases()
    {
        return await Get<SpotifyDto>("/album/new-releases");
    }

    public async Task<Profile?> GetProfile(string token)
    {
        return await Get<Profile>($"/profile/get/{token}");
    }

    public async Task<ArtistCollection?> GetTopArtists(string token)
    {
        return await Get<ArtistCollection>($"/profile/topartists/{token}");
    }

    public async Task<TrackCollection?> GetTopTracks(string token)
    {
        return await Get<TrackCollection>($"/profile/toptracks/{token}");
    }

    public async Task<SpotifyDto?> Search(string query)
    {
        var path = $"/Search/{query}";
        return await Get<SpotifyDto>(path);
    }

    private async Task<T?> Get<T>(string path)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}{path}");
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent != null)
                {
                    return JsonSerializer.Deserialize<T>(responseContent);
                }
            }
            return default;
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException("Error: " + e.Message);
        }
    }
}