using Microsoft.AspNetCore.WebUtilities;
using PersonaliTune.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PersonaliTune.Spotify.Api.Services;

public class SpotifyService : ISpotifyService
{
    private readonly HttpClient _httpClient;
    private readonly string clientId;
    private readonly string clientSecret;
    private readonly Uri tokenUrl;
    private readonly Uri authorizeUrl;
    private readonly Uri baseUrl;
    private readonly Uri callBackUrl;

    public SpotifyService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        clientId = configuration["Spotify:ClientID"] ?? string.Empty;
        clientSecret = configuration["Spotify:Test"] ?? string.Empty;
        tokenUrl = new Uri(configuration["Spotify:TokenUrl"] ?? string.Empty);
        authorizeUrl = new Uri(configuration["Spotify:AuthorizeUrl"] ?? string.Empty);
        baseUrl = new Uri(configuration["Spotify:BaseUrl"] ?? string.Empty);
        callBackUrl = new Uri(configuration["Spotify:CallBackUrl"] ?? string.Empty);
    }

    public string GetLoginUrl()
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "client_id", clientId },
            { "response_type", "code" },
            { "redirect_uri", callBackUrl.AbsoluteUri },
            { "scope", "user-read-private playlist-read-private user-read-email user-top-read user-follow-read" },
            //{ "code_challenge_method", "S256" },
            //{ "code_challenge", challenge }

        };
        var url = new Uri(QueryHelpers.AddQueryString(
            authorizeUrl.AbsoluteUri, queryParams));
        return url.ToString();
    }

    public async Task<string> GetPrivateContentAsync(string token, string endpoint)
    {
        return await GetByTokenAsync(token, endpoint);
    }

    public async Task<string> GetPublicContentAsync(string endpoint)
    {
        var token = await GetToken();
        return await GetByTokenAsync(token, endpoint);
    }

    private async Task<string> GetToken()
    {
        var parameters = new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" },
            { "client_id", clientId.ToString() },
            { "client_secret", clientSecret.ToString() },
        };

        return await GetToken(parameters);
    }

    public async Task<string> GetToken(string code)
    {
        try
        {
            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "redirect_uri", "https://localhost:7238/callback" },
                { "code", code },
                { "client_id", clientId.ToString() },
                { "client_secret", clientSecret.ToString() },
            };

            return await GetToken(parameters);
        }
        catch (Exception e)
        {
            throw new Exception("Error retrieving token from Spotify", e);
        }
    }

    private async Task<string> GetToken(Dictionary<string, string> parameters)
    {
        var content = new FormUrlEncodedContent(parameters);

        var httpClient = new HttpClient();

        var response = await httpClient.PostAsync(tokenUrl, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            var token = JsonSerializer.Deserialize<Token>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var expiresIn = token.Expires_In;
            return token.Access_Token;
        }
        else
        {
            throw new Exception($"Failed to retrieve access token. Status code: {response.StatusCode}");
        }
    }

    private async Task<string> GetByTokenAsync(string token, string endpoint)
    {
        Uri requestUri = new Uri(baseUrl, endpoint);

        try
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = requestUri,
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

            HttpResponseMessage response = await _httpClient.SendAsync(message);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                throw new Exception($"Request failed with status code {response.StatusCode}");
            }
        }
        catch (Exception e)
        {
            throw new Exception("Error posting to Spotify", e);
        }
    }

    //private async Task<string> GetByClientCredentialsTokenAsync(string token, string endpoint)
    //{
    //    Uri requestUri = new Uri(baseUrl, endpoint);

    //    try
    //    {
    //        var message = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = requestUri,
    //        };
    //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

    //        HttpResponseMessage response = await _httpClient.SendAsync(message);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            var responseContent = await response.Content.ReadAsStringAsync();
    //            return responseContent;
    //        }
    //        else
    //        {
    //            throw new Exception($"Request failed with status code {response.StatusCode}");
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        throw new Exception("Error posting to Spotify", e);
    //    }
    //}
}

