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
    class UserDao : IUserDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public UserDao(ADbCommProvider dbDbCommProvider)
        {
            this._dbCommProvider = dbDbCommProvider;
        }

        private User CreateUserObject(IDataReader dataReader)
        {
            var user = new User
            {
                UserId = (int)dataReader["UserId"],
                FistName = (string)dataReader["FirstName"],
                LastName = (string)dataReader["LastName"],
                EMail = (string)dataReader["UserMail"],
                Password = (string)dataReader["Password"],
                IsAdmin = (bool)dataReader["IsAdmin"],
                IsArtist = (bool)dataReader["IsArtist"]
            };

            if (!(dataReader["ArtistId"] is DBNull))
            {
                var artist = new Artist
                {
                    ArtistId = (int) dataReader["ArtistId"],
                    Name = dataReader["ArtistName"] is DBNull ? null : (string) dataReader["ArtistName"],
                    EMail = (string) dataReader["ArtistMail"],
                    PromoVideo = dataReader["PromoVideo"] is DBNull ? null : (string) dataReader["PromoVideo"],
                    Picture = dataReader["Picture"] is DBNull ? null : BlobData.CreateBlobData((string) dataReader["Picture"]),
                    Country = new Country
                    {
                        Code = (string) dataReader["CountryCode"],
                        Name = (string) dataReader["CountryName"]
                    }
                };
                if (!(dataReader["CategoryId"] is DBNull))
                {
                    artist.Category = new Category
                    {
                        CategoryId = (string) dataReader["CategoryId"],
                        Name = (string) dataReader["CategoryName"]
                    };
                }
                user.Artist = artist;
            }

            return user;
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
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAllUser))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    users.Add(CreateUserObject(dataReader));
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
