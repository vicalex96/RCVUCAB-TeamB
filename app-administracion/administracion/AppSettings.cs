using Microsoft.Extensions.Configuration;

namespace administracion.Configurations
{
    public class AppSettings
    {
        private readonly string _dbconnectionString = string.Empty;
        private readonly string _dbconnectionTestString = string.Empty;
        private readonly string _mqconnectionString = string.Empty;

        public AppSettings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _dbconnectionString = root.GetSection("ConnectionStrings").GetSection("DataBaseConnection").Value;
            _dbconnectionTestString = root.GetSection("ConnectionStrings").GetSection("DataBaseTestConnection").Value;
            _mqconnectionString = root.GetSection("ConnectionStrings").GetSection("MQConnection").Value;
        }
        public string DBConnectionString
        {
            get => _dbconnectionString;
        }
        public string DBConnectionTestString
        {
            get => _dbconnectionTestString;
        }

        public string MQConnectionString
        {
            get => _mqconnectionString;
        }
    }
}
