using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FH.SEv.UFO.Server.Properties;
using MySql.Data.MySqlClient;

namespace FH.SEv.UFO.Server.Provider
{
    public sealed class DbCommProviderFactory
    {
        public static DbConnection CreateDbConnection(string dbProviderName = null, string connectionString = null)
        {
            var connection = new MySqlConnection(connectionString ?? Settings.Default.DbConnectionString);
            // TODO: Find out why the GetFactory method does't work!
            //var factory = DbProviderFactories.GetFactory(dbProviderName ?? Settings.Default.DbProviderName);
            //var connection = factory.CreateConnection();
            //if (connection != null)
            //    connection.ConnectionString = connectionString ?? Settings.Default.DbConnectionString;
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
