using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace OfficeApp.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string Username
        {
            get => AppSettings.GetValueOrDefault("Username", "");
            set => AppSettings.AddOrUpdateValue("Username", value);
        }
        public static string Password
        {
            get => AppSettings.GetValueOrDefault("Password", "");
            set => AppSettings.AddOrUpdateValue("Password", value);
        }
        public static string Jwt
        {
            get => AppSettings.GetValueOrDefault("Jwt", "");
            set => AppSettings.AddOrUpdateValue("Jwt", value);
        }
        public static DateTime JwtExpirationDate
        {
            get => AppSettings.GetValueOrDefault("JwtExpirationDate", DateTime.UtcNow);
            set => AppSettings.AddOrUpdateValue("JwtExpirationDate", value);
        }
    }
}
