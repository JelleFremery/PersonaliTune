using Microsoft.AspNetCore.Mvc;
using PersonaliTune.Spotify.Api.Services;

namespace PersonaliTune.Spotify.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    [Route("get/{token}")]
    public async Task<string> Get(string? token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        return await _profileService.Get(token);
    }

    [HttpGet]
    [Route("topartists/{token}")]
    public async Task<string> GetTopArtists(string? token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        return await _profileService.GetTopArtists(token);
    }

    [HttpGet]
    [Route("toptracks/{token}")]
    public async Task<string> GetTopTracks(string? token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        return await _profileService.GetTopTracks(token);
    }
}