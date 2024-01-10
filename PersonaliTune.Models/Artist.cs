namespace PersonaliTune.Models;

public class Artist
{
    public ExternalUrls? external_urls { get; set; }
    public string? href { get; set; }
    public string? id { get; set; }
    public string? name { get; set; }
    public string? type { get; set; }
    public string? uri { get; set; }
    public int? popularity { get; set; }
    public List<Image>? images { get; set; }
    public List<string>? genres { get; set; }
    public List<Album>? items { get; set; }
}
