using Xamarin.Essentials;

namespace Tindero.Settings
{
    public static class UserSettings
    {
        private const string userIdKey = "userIdKey";

        public static int Id
        {
            get => Preferences.Get(userIdKey, -1);
            set => Preferences.Set(userIdKey, value);
        }
    }
}
