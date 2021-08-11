using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace My.Namespace
{
    public class AppSettings
    {

        public class ConnectionStrings
        {
            public Dictionary<string, string> AvailableConnections { get; set; }

            public string GetConnectionString(string conn)
            {
                return AvailableConnections[conn];
            }

        }

        public ConnectionStrings connStrings { get; set; } = new ConnectionStrings();

        public static IConfiguration GetConfiguration(string dir, string env)
        {
            if (string.IsNullOrEmpty(env))
                env = "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        public static AppSettings GetSettings(string dir, string environmentName)
        {
            var config = GetConfiguration(dir, environmentName);
            return GetSettings(config);
        }

        public static AppSettings GetSettings(IConfiguration config)
        {
            return config.Get<AppSettings>();
        }
    }
}