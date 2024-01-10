using Microsoft.AspNetCore.Mvc;
using PersonaliTune.Spotify.Api.Services;

namespace PersonaliTune.Spotify.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController : ControllerBase
{
    private readonly ISpotifyService _spotifyService;

    public TokenController(ISpotifyService spotifyService)
    {
        _spotifyService = spotifyService;
    }

    [HttpGet]
    [Route("login")]
    public string Login()
    {
        return _spotifyService.GetLoginUrl();
    }

    [HttpGet]
    [Route("get/{code}")]
    public async Task<string> Get(string? code)
    {
        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentNullException(nameof(code));
        }

        return await _spotifyService.GetToken(code);
    }
}

