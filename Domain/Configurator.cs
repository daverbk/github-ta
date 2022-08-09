using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Domain
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> Config;

        private static IConfiguration Configuration => Config.Value;

        public static string BaseUrl => Configuration[nameof(BaseUrl)];
        
        public static string BrowserType => Configuration[nameof(BrowserType)];
        
        public static int SeleniumWaitTimeout => int.Parse(Configuration[nameof(SeleniumWaitTimeout)]);

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
