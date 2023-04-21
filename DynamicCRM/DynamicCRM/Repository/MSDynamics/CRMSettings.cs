
namespace UoPeople.NGPortal.Service.Settings
{
    public class CRMSettings
    {
        public string ClientId { get; init; }

        public string ClientSecret { get; init; }

        public string Environment { get; init; }

        public string ConnectionString => $"Url=https://{Environment}.dynamics.com;AuthType=ClientSecret;ClientId={ClientId};ClientSecret={ClientSecret}";
    }
}