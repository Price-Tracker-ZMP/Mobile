using Plugin.Settings;
using Plugin.Settings.Abstractions;

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

        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(Username), "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(Username), value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(Password), "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(Password), value);
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
    }
}
