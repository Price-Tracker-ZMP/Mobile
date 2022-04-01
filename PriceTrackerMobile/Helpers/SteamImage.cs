namespace PriceTrackerMobile.Helpers
{
    class SteamImage
    {
        public static string FromId(int id)
        {
            return $"https://cdn.akamai.steamstatic.com/steam/apps/{id}/header.jpg";
        }
    }
}
