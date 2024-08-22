using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_DataAccessLayer.DatabaseConnection
{
    public static class DbConnection
    {
        private static IConfigurationRoot? _configuration;

        static DbConnection()
        {
            var builder = new ConfigurationBuilder()
                          .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            _configuration = builder.Build();
        }

        public static string? GetConnectionString => _configuration?.GetConnectionString("MyDB");
        
    }
}
