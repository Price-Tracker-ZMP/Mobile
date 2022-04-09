using Newtonsoft.Json;

namespace PriceTrackerMobile.Models
{
    public class FetchedGame
    {
        [JsonProperty("appid")]
        public long Appid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
