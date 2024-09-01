using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_Utilities
{
    public static class DbConnection
    {
        public static string GetConnectionString => AppSettingsConfiguration.GetConnectionString;
    }
}
