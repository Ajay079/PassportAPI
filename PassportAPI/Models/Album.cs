using Newtonsoft.Json;

namespace PassportAPI.Models
{
    public class Album
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int AlbumId { get; set; }

        [JsonProperty("title")]
        public string AlbumTitle { get; set; }
    }
}
