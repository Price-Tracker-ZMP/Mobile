using Newtonsoft.Json;
using PriceTrackerMobile.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public class SteamGamesService
    {
        public static async Task<List<Game>> FetchSteamGames()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://api.steampowered.com/ISteamApps/GetAppList/v0002/?format=json");
            var rString = await response.Content.ReadAsStringAsync();
            var convertedJson = JsonConvert.DeserializeObject<SteamGameList>(rString);

            var fetchedGames = convertedJson.Applist.Apps;
        }
    }
}
