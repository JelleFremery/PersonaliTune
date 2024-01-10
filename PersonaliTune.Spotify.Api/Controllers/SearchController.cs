using Microsoft.AspNetCore.Mvc;
using PersonaliTune.Spotify.Api.Services;

namespace PersonaliTune.Spotify.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    [Route("{query}")]
    public async Task<string> SearchForArtistOrAlbum(string query)
    {
        if (query == null)
        {
            throw new Exception("Search query needs a value");
        }

        query = query.Replace(" ", "");

        var result = await _searchService.SearchArtistOrAlbumOrTrack(query);
        return result;
    }
}

