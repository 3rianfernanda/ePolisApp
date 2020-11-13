using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
public static class ConfigDataAccess
{
    private static IConfigurationRoot _configuration;
    public static IConfigurationRoot Configuration
    {
        get
        {
            if (_configuration != null)
            {
                return _configuration;
            }
            else
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                _configuration = builder.Build();

                return _configuration;
            }
        }
    }
}