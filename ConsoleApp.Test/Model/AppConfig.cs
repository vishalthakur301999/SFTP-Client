using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Test
{
    public class AppConfig
    {
        public IConfigurationRoot Config { get; private set; }

        private static AppConfig _instance = null;
        public static AppConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppConfig();
                }
                return _instance;
            }
        }

        private AppConfig()
        {
            Config = Build();
        }

        private static IConfigurationRoot Build()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .AddXmlFile(Path.Combine(AppContext.BaseDirectory, "ConfigFile", "Test.xml"), optional: true);
            IConfigurationRoot configuration = builder.Build();
            return configuration;
        }
    }
}
