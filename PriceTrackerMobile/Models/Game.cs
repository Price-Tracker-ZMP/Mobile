using Newtonsoft.Json;
using PriceTrackerMobile.Helpers;

namespace PriceTrackerMobile.Models
{
    public class Game
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("discountPercent")]
        public long DiscountPercent { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("priceFinal")]
        public long PriceFinal { get; set; }
        [JsonProperty("priceInitial")]
        public long PriceInitial { get; set; }
        [JsonProperty("steam_appid")]
        public long SteamAppId { get; set; }
        public string ImageUrl
        {
            get
            {
                return SteamImage.FromId(SteamAppId);
            }
            set
            {
                ImageUrl = value;
            }
        }
    }
}
