using Microsoft.AspNetCore.Mvc;
using PersonaliTune.Spotify.Api.Services;

namespace PersonaliTune.Spotify.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<string> GetAlbumById(string id)
    {
        var album = await _albumService.GetAlbumById(id);
        return album;
    }

    [HttpGet]
    [Route("new-releases")]
    public async Task<string> GetNewReleases()
    {
        var newReleases = await _albumService.GetNewReleases();
        return newReleases;
    }
}

