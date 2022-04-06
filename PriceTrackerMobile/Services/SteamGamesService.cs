using Newtonsoft.Json;
using PriceTrackerMobile.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public class SteamGamesService
    {
        public static async Task<List<FetchedGame>> FetchSteamGames()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://api.steampowered.com/ISteamApps/GetAppList/v0002/?format=json").ConfigureAwait(false);
            string rString = await response.Content.ReadAsStringAsync();
            SteamGameList convertedJson = JsonConvert.DeserializeObject<SteamGameList>(rString);

            return convertedJson.Applist.Apps;
        }
    }
}
