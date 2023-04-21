using System.Collections.Concurrent;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace UoPeople.NGPortal.Service.Repository.MSDynamics.Connection
{

    public class CRMConnectionPoolManager : ICRMConnectionPoolManager
    {
        private readonly object _lock = new object();
        private readonly ConcurrentQueue<ServiceClient> _pool;
        private readonly string _connectionString;
        private readonly int _maxPoolSize;

        public CRMConnectionPoolManager(string connectionString, int maxPoolSize)
        {
            _pool = new ConcurrentQueue<ServiceClient>();
            _connectionString = connectionString;
            _maxPoolSize = maxPoolSize;
        }

        public ServiceClient GetConnection(TimeSpan timeout)
        {
            if (_pool.TryDequeue(out ServiceClient connection))
            {
                return connection;
            }

            lock (_lock)
            {

                if (_pool.Count < _maxPoolSize)
                {
                    connection = new ServiceClient(_connectionString);
                    _pool.Enqueue(connection);
                    return connection;
                }

                if (timeout == TimeSpan.Zero)
                {
                    throw new Exception("Connection pool has reached maximum size and no connections are available.");
                }

                if (!_pool.TryDequeue(out connection))
                {
                    var startTime = DateTime.UtcNow;
                    var endTime = startTime.Add(timeout);

                    do
                    {
                        if (_pool.TryDequeue(out connection))
                        {
                            return connection;
                        }

                        Thread.Sleep(50);
                    } while (DateTime.UtcNow < endTime);

                    throw new Exception("Timed out while waiting for a connection to become available in the pool.");
                }
            }

            return connection;
        }

        public void ReturnConnection(ServiceClient connection)
        {
            if (connection == null)
            {
                return;
            }

            _pool.Enqueue(connection);
        }
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