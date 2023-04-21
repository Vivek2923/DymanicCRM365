
using Microsoft.PowerPlatform.Dataverse.Client;

namespace UoPeople.NGPortal.Service.Repository.MSDynamics.Connection
{
    public interface IDynamicsConnectionManager
    {
        public ServiceClient getConnection();
    }
}
