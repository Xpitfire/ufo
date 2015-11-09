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
using System.Collections.Generic;
using System.Data;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class MySqlUserDao : IUserDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public MySqlUserDao(ADbCommProvider dbDbCommProvider)
        {
            _dbCommProvider = dbDbCommProvider;
        }

        public DaoResponse<User> UpdateUserCredentials(User user)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(
                connection,
                @"UPDATE user SET FirstName=@FirstName, LastName=@LastName, Password=@Password, EMail=@EMail, IsAdmin=@IsAdmin, IsArtist=@IsArtist, ArtistID=@ArtistID WHERE ID=@ID", 
                new Dictionary<string, Tuple<DbType, object>>
                {
                    { "ID", new Tuple<DbType, object>(DbType.Int32, user.Id) },
                    { "FirstName", new Tuple<DbType, object>(DbType.String, user.FistName) },
                    { "LastName", new Tuple<DbType, object>(DbType.String, user.LastName) },
                    { "Password", new Tuple<DbType, object>(DbType.String, user.PasswordHash) },
                    { "EMail", new Tuple<DbType, object>(DbType.String, user.EMail) },
                    { "IsAdmin", new Tuple<DbType, object>(DbType.Boolean, user.IsAdmin) },
                    { "IsArtist", new Tuple<DbType, object>(DbType.Boolean, user.IsArtist) },
                    { "ArtistID", new Tuple<DbType, object>(DbType.Int32, user.ArtistId) }
                }))
            {
                _dbCommProvider.ExecuteNonQuery(command);
                return DaoResponse.QuerySuccessfull(user);
            }
        }

        public DaoResponse<IList<User>> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, @"SELECT * FROM user"))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    var user = new User
                    {
                        Id = (int) dataReader["ID"],
                        FistName = (string) dataReader["FirstName"]
                    };
                    users.Add(user);
                }
            }
            return DaoResponse.QuerySuccessfull<IList<User>>(users);
        }

        public DaoResponse<IList<User>> GetUsers<T>(T criteria, Filter<User, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<User>>(
                new List<User>(filter.Invoke(GetAllUsers().ResultObject, criteria)));
        }
    }
}
