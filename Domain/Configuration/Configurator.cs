using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Domain.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> Config;

        private static IConfiguration Configuration => Config.Value;

        public static string BaseApiUrl => Configuration[nameof(BaseApiUrl)];
        
        public static string BrowserType => Configuration[nameof(BrowserType)];

        static Configurator()
        {
            Config = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
