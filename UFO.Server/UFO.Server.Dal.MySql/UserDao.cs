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
using MySql.Data.MySqlClient;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class UserDao : IUserDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public UserDao(ADbCommProvider dbDbCommProvider)
        {
            _dbCommProvider = dbDbCommProvider;
        }

        public DaoResponse<User> Update(User user)
        {
            var paramter = new Dictionary<string, QueryParameter>
            {
                {"?UserId", new QueryParameter {ParameterValue = user.UserId}},
                {"?FirstName", new QueryParameter {ParameterValue = user.FistName}},
                {"?LastName", new QueryParameter {ParameterValue = user.LastName}},
                {"?Password", new QueryParameter {ParameterValue = user.Password}},
                {"?IsAdmin", new QueryParameter {ParameterValue = user.IsAdmin}},
                {"?IsArtist", new QueryParameter {ParameterValue = user.IsArtist}},
                {"?ArtistId", new QueryParameter {ParameterValue = user.Artist?.ArtistId}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateUser, paramter))
            {
                _dbCommProvider.ExecuteNonQuery(command);
                return DaoResponse.QuerySuccessfull(user);
            }
        }

        public DaoResponse<IList<User>> GetAll()
        {
            var users = new List<User>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand<MySqlDbType>(connection, @"SELECT * FROM user"))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    var user = new User
                    {
                        UserId = (int) dataReader["UserId"],
                        FistName = (string) dataReader["FirstName"],
                        LastName = (string) dataReader["LastName"],
                        EMail = (string) dataReader["EMail"],
                        Password = (string) dataReader["Password"],
                        IsAdmin = (bool) dataReader["IsAdmin"],
                        IsArtist = (bool) dataReader["IsArtist"]
                    };
                    if (user.IsArtist)
                    {
                        //using (var connection2 = _dbCommProvider.CreateDbConnection())
                        //using (var command2 = _dbCommProvider.CreateDbCommand(
                        //    connection, 
                        //    SqlQueries.SelectArtistById,
                        //    new Dictionary<string, Tuple<DbType, object>>
                        //    {
                        //        { "ArtistId", new Tuple<DbType, object>(DbType.Int32, user.ArtistId) }
                        //    }))
                        //using (var dataReader2 = _dbCommProvider.ExecuteReader(command))
                        //{
                        //    while (dataReader.Read())
                        //    {
                        //        var artist = new Artist
                        //        {
                        //            ArtistId = (int) dataReader2["ArtistId"],
                        //            Name = (int) dataReader2["ArtistId"],
                        //            EMail = (int) dataReader2["ArtistId"],
                        //            CategoryId = (int) dataReader2["ArtistId"],
                        //             = (int) dataReader2["ArtistId"],
                        //            ArtistId = (int) dataReader2["ArtistId"]
                        //        };
                        //    }
                        //}
                    }
                    users.Add(user);
                }
            }
            return DaoResponse.QuerySuccessfull<IList<User>>(users);
        }

        public DaoResponse<IList<User>> GetAllAndFilterBy<T>(T criteria, Filter<User, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<User>>(
                new List<User>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}
