using Microsoft.Extensions.Configuration;

namespace Buecherverwaltung.Utilis
{
    // Dependency Injection - Erstellung eines Konfigurationslesers, welcher die Konfiguration auslesen kann und den ConnectionString zur DB ausliest
    public class KonfigurationsLeser : IKonfigurationsLeser
    {
        private readonly IConfiguration _configuration;

        public KonfigurationsLeser(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string LiesDatenbankVerbindungZurMariaDB()
        {
            return _configuration.GetConnectionString("MariaDB");
        }
    }

    public interface IKonfigurationsLeser
    {
        string LiesDatenbankVerbindungZurMariaDB();
    }
}
