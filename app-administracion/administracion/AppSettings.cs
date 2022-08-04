using Microsoft.Extensions.Configuration;

namespace administracion.Configurations
{
    public class AppSettings
    {
        public readonly string _dbconnectionString = string.Empty;
        public readonly string _mqconnectionString = string.Empty;

        public AppSettings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _dbconnectionString = root.GetSection("ConnectionStrings").GetSection("DataBaseConnection").Value;
            _mqconnectionString = root.GetSection("ConnectionStrings").GetSection("MQConnection").Value;
        }
        public string DBConnectionString
        {
            get => _dbconnectionString;
        }

        public string MQConnectionString
        {
            get => _mqconnectionString;
        }
    }
}
