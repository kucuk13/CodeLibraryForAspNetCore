namespace MigrationExample.Helpers
{
    public class AppSettingsHelper
    {
        public static string GetValue(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();
            return configuration[key];
        }
    }
}
