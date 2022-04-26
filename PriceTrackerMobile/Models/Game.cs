using Newtonsoft.Json;
using PriceTrackerMobile.Helpers;

namespace PriceTrackerMobile.Models
{
    public class Game
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("discountPercent")]
        public int DiscountPercent { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        float priceFinal;
        [JsonProperty("priceFinal")]
        public float PriceFinal
        {
            get { return priceFinal; }
            set { priceFinal = value / 100; }
        }
        float priceInitial;
        [JsonProperty("priceInitial")]
        public float PriceInitial
        {
            get { return priceInitial; }
            set { priceInitial = value / 100; }
        }
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

        public Game()
        {
        }
    }
}
