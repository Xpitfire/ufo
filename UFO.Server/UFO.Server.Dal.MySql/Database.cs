#region copyright
// (C) Copyright 2015 Dinu Marius-Constantin (http://dinu.at) and others.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Contributors:
//     Dinu Marius-Constantin
//     Wurm Florian
#endregion
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;
using UFO.Server.Dal.Common;

namespace UFO.Server.Dal.MySql
{
    public class Database : IDatabase
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public DbCommand CreateCommand(string commandText)
        {
            return new SqlCommand(commandText);
        }

        public int DeclareParameter(DbCommand command, string name, DbType type)
        {
            if (!command.Parameters.Contains(name))
            {
                return command.Parameters.Add(new SqlParameter(name, type));
            }

            throw new ArgumentException($"Parameter {name} already exists");
        }

        public void SetParameter(DbCommand command, string name, object value)
        {
            if (command.Parameters.Contains(name))
            {
                command.Parameters[name].Value = value;
            }
            throw new ArgumentException($"Parameter {name} is not declared");
        }

        public void DefineParameter(DbCommand command, string name, DbType type, object value)
        {
            int paramIndex = DeclareParameter(command, name, type);
            command.Parameters[paramIndex].Value = value;
        }

        public IDataReader ExecuteReader(DbCommand command)
        {
            DbConnection connection = null;
            try
            {
                connection = GetOpenConnection();
                command.Connection = connection;

                // let the reader close the connection only if it is not shared
                var behavior = Transaction.Current == null ? 
                    CommandBehavior.CloseConnection : 
                    CommandBehavior.Default;

                return command.ExecuteReader(behavior);
            }
            catch
            {
                ReleaseConnection(connection);
                throw;
            }
        }

        public int ExecuteNonQuery(DbCommand command)
        {
            DbConnection connection = null;
            try
            {
                connection = GetOpenConnection();
                command.Connection = connection;
                return command.ExecuteNonQuery();
            }
            finally
            {
                ReleaseConnection(connection);
            }
        }

        #region connection management

        [ThreadStatic]
        private static DbConnection _sharedConnection;

        private DbConnection CreateOpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private DbConnection GetOpenConnection()
        {
            Transaction currentTransaction = Transaction.Current;

            if (currentTransaction == null)
            {
                return CreateOpenConnection();
            }

            if (_sharedConnection == null)
            {
                _sharedConnection = CreateOpenConnection();
                currentTransaction.TransactionCompleted += 
                    (s, e) =>  
                    {
                        _sharedConnection.Close();
                        _sharedConnection = null;
                    };
            }

            return _sharedConnection;
        }

        private void ReleaseConnection(DbConnection connection)
        {
            // close connection if no transaction is active
            if (connection != null && Transaction.Current == null)
            {
                connection.Close();
            }
        }

        #endregion
    }
}
