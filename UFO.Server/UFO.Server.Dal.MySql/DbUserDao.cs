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
using System.Data.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class DbUserDao : IUserDao
    {
        public DaoResponse<User> UpdateUserCredentials(User user)
        {
            using (var connection = DbCommProviderFactory.CreateDbConnection())
            using (var command = DbCommProviderFactory.CreateDbCommand(connection, @"UPDATE user SET FirstName=@FirstName WHERE ID=@ID"))
            {
                throw new NotImplementedException();
            }
        }

        public IList<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = DbCommProviderFactory.CreateDbConnection())
            using (var command = DbCommProviderFactory.CreateDbCommand(connection, @"SELECT * FROM user"))
            using (IDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var user = new User
                    {
                        ArtistId = (int) dataReader["ID"],
                        FistName = (string) dataReader["FirstName"]
                    };
                    users.Add(user);
                }
            }
            return users;
        }

        public IList<User> GetUsers<T>(T criteria, Filter<User, T> filter)
        {
            throw new NotImplementedException();
        }
    }
}
