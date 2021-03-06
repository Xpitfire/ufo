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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class UserDeo : IUserDao
    {
        public DaoResponse<User> Insert(User entity)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<User> Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<User> Delete(User entity)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<long> Count()
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<List<User>> SelectAll()
        {
            return DaoResponse.QuerySuccessful<List<User>>(DataCollection.Users.ToList());
        }

        public DaoResponse<List<User>> Select(PagingData page)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<User> SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<bool> VerifyAdminCredentials(User user)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<List<User>> SelectByKeyword(string keyword)
        {
            throw new System.NotImplementedException();
        }
    }
}
