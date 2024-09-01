using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_Utilities
{
    public class AppSettingsConfiguration
    {

        private static IConfigurationRoot _configuration;

        static AppSettingsConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                          .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"),false)
                          .Build();
            _configuration = configuration;
        }

        public static string? GetConnectionString => _configuration?.GetConnectionString("MyDB");

        public static T GetConfig<T>(string key)
        {
            return (T)_configuration.GetSection(key).Get<T>();
        }
    }
}
