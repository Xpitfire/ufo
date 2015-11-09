﻿#region copyright
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

        public static DbCommand CreateDbCommand(DbConnection connection, string queryText, DbParameter parameter = null)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandText = queryText;
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            if (parameter != null)
                command.Parameters.Add(parameter);
            return command;
        }
    }
}
