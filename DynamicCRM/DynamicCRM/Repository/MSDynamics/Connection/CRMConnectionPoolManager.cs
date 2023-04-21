using Microsoft.PowerPlatform.Dataverse.Client;

namespace UoPeople.NGPortal.Service.Repository.MSDynamics.Connection
{
    public interface ICRMConnectionPoolManager
    {
        ServiceClient GetConnection(TimeSpan timeout);
        void ReturnConnection(ServiceClient connection);
    }




    //var connection = poolManager.GetConnection(TimeSpan.FromSeconds(10));
    // Get a connection from the pool
    /*
var connection = ConnectionPoolManager.Instance.GetConnection();
try
{
    // Use the connection to perform some operations on Dynamics 365 or Power Apps
    // ...
}
finally
{
    // Return the connection to the pool when finished
    ConnectionPoolManager.Instance.ReturnConnection(connection);
}
*/


}