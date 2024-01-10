using PersonaliTune.Models;
using PersonaliTune.Models.Prompts;

namespace PersonaliTune.AzureOpenAI.Api.PromptTemplates.NewArtistRecommendation;

public class NewArtistRecommendationUserTemplate : IPromptTemplate
{
    private readonly Artist _artist;
    private static readonly Random _random = new();

    public NewArtistRecommendationUserTemplate(ArtistCollection artists)
    {
        _artist = SelectRandomTopFiveArtist(artists);
    }

    public string GetPromptRole() => PromptRole.User;

    public string GetPromptMessage()
    {
        return @"I like " + _artist.name
            + @". Can you recommend me a similar, but lesser known artist?"
            + @" Please give a brief overview of the artist and a few reasons why you think I'd like the artist."
            + @" Your answer should be around 500 words long.";
    }

    private static Artist SelectRandomTopFiveArtist(ArtistCollection model)
    {
        var artists = model.items.OrderByDescending(x => x.popularity).ToArray();
        var index = _random.Next(0, int.Max(4, artists.Length));
        return artists[index];
    }
}
