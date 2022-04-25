using Plugin.Settings;
using Plugin.Settings.Abstractions;
using PriceTrackerMobile.Models;
using System.Collections.Generic;

namespace PriceTrackerMobile.Helpers
{

    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static bool AutoLogIn
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(AutoLogIn), false);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(AutoLogIn), value);
            }
        }

        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(Token), "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(Token), value);
            }
        }

        public static List<FetchedGame> AvailableGames = new List<FetchedGame>();
    }
}
