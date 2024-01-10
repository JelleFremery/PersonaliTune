using Microsoft.AspNetCore.Mvc;
using PersonaliTune.Spotify.Api.Services;

namespace PersonaliTune.Spotify.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{

    private readonly IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<string> GetArtistById(string id)
    {
        var artist = await _artistService.GetArtistById(id);
        return artist;
    }

    [HttpGet]
    [Route("{id}/albums")]
    public async Task<string> GetArtistAlbum(string id)
    {
        var artist = await _artistService.GetArtistAlbum(id);
        return artist;
    }
}

