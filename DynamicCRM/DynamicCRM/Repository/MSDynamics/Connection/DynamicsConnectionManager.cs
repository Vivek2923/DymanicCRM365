
using Microsoft.PowerPlatform.Dataverse.Client;
using UoPeople.NGPortal.Service.Settings;

namespace UoPeople.NGPortal.Service.Repository.MSDynamics.Connection
{

    public class DynamicsConnectionManager : IDynamicsConnectionManager
    {
        private readonly string _crmConnectionString;
        private ServiceClient _connection = null;

        private static readonly object _lock = new object();

        public DynamicsConnectionManager(IConfiguration configuration)
        {
            var crmSettings = configuration.GetSection(nameof(CRMSettings)).Get<CRMSettings>();
            _crmConnectionString = crmSettings.ConnectionString;
        }

        public ServiceClient getConnection()
        {

            if (_connection == null)
            {
                lock (_lock)
                {
                    if (_connection == null)
                    {
                        doConnect();
                    }
                }
            }

            return _connection;
        }

        private void doConnect()
        {
            try
            {
                _connection = new ServiceClient(_crmConnectionString);
                if (!_connection.IsReady)
                {
                    throw new Exception($"Problem connecting to Dynamic CRM server.Error details: {_connection?.LastError}");
                }
            }
            catch (Exception ex)
            {
                //"Problem connecting to Dynamic CRM server.Error details: {_connection?.LastError}");
                throw ex;
            }
        }

    }
}
