using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SarfMalzemeStok.Domain.Configurations
{
    public class DbConfiguration
    {
        public static string GetConnectionString(string connectionStringName)
        {
            var path = Directory.GetCurrentDirectory();
            var configuration = AppConfigurations.Get(path);
            string conString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(configuration, connectionStringName);
            return conString;
        }
    }
}
