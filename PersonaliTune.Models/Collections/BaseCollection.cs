using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PersonaliTune.Models
{
    public abstract class BaseCollection
    {
        public string href { get; set; }
        public int limit { get; set; }
        public string? next { get; set; }
        public int offset { get; set; }
        public string? previous { get; set; }
        public int total { get; set; }
    }
}

//    public class TopTrackCollectionDto : BaseCollection
//    {
//        public List<TopTrackDto> items { get; set; }
//    }

//    public class TopArtistCollectionDto : BaseCollection
//    {
//        public List<TopArtistDto> items { get; set; }
//    }

//    public class TopTrackDto
//    {
//        public Album album { get; set; }
//        public List<Artist> artists { get; set; }
//        public List<string> available_markets { get; set; }
//        public int disc_number { get; set; }
//        public int duration_ms { get; set; }
//        [JsonPropertyName("explicit")]
//        public bool _explicit { get; set; }
//        public ExternalIds external_ids { get; set; }
//        public ExternalUrls external_urls { get; set; }
//        public string href { get; set; }
//        public string id { get; set; }
//        public string name { get; set; }
//        public int popularity { get; set; }
//        public string preview_url { get; set; }
//        public int track_number { get; set; }
//        public string type { get; set; }
//        public string uri { get; set; }
//        public bool is_local { get; set; }
//    }

//    public class TopArtistDto
//    {
//        public ExternalUrls external_urls { get; set; }
//        public Followers followers { get; set; }
//        public List<string> genres { get; set; }
//        public string href { get; set; }
//        public string id { get; set; }
//        public List<Image> images { get; set; }
//        public string name { get; set; }
//        public int popularity { get; set; }
//        public string type { get; set; }
//        public string uri { get; set; }
//    }
//}