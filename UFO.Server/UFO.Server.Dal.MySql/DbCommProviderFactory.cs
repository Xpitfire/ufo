using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using UFO.Server.Dal.MySql.Properties;

namespace UFO.Server.Dal.MySql
{
    public sealed class DbCommProviderFactory
    {
        public static DbConnection CreateDbConnection(string dbProviderName = null, string connectionString = null)
        {
            var connection = new MySqlConnection(connectionString ?? Settings.Default.DbConnectionString);
            connection.Open();
            return connection;
        }

        public static IDbCommand CreateDbCommand(DbConnection connection, string queryText)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = queryText;
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            return command;
        }
    }
}
