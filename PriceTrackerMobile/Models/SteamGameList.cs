using Newtonsoft.Json;
using System.Collections.Generic;

namespace PriceTrackerMobile.Models
{
    class SteamGameList
    {
        [JsonProperty("applist")]
        public Applist Applist { get; set; }
    }

    public class Applist
    {
        [JsonProperty("apps")]
        public List<FetchedGame> Apps { get; set; }
    }

    public class FetchedGame
    {
        [JsonProperty("appid")]
        public long Appid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
