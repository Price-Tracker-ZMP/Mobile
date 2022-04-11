namespace PriceTrackerMobile.Models
{
    public class Game
    {
        public string Currency { get; set; }
        public long DiscountPercent { get; set; }
        public string Name { get; set; }
        public long PriceFinal { get; set; }
        public long PriceInitial { get; set; }
        public long SteamAppId { get; set; }
        public string ImageUrl { get; set; }
    }
}
