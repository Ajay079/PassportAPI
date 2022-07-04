using Newtonsoft.Json;

namespace PassportAPI.Models
{
    public class Photo
    {
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }

        [JsonProperty("id")]
        public int PhotoId { get; set; }
        
        [JsonProperty("title")]
        public string PhotoTitle { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
    }
}
