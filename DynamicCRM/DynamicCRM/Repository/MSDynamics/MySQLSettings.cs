
namespace UoPeople.NGPortal.Service.Settings
{
    public class MySQLSettings
    {
        public string Server { get; init; }

        public int Port { get; init; }

        public string UserName { get; init; }

        public string Password { get; init; }

        public string DBName { get; init; }

        public string ConnectionString => $"server={Server};port={Port};user={UserName};password={Password};database={DBName}";

    }
}