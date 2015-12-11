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
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;
using PostSharp.Constraints;

namespace UFO.Server.Bll.Common
{
    [ServiceContract]
    public interface IAuthAccessBll
    {
        // user
        [OperationContract]
        IList<User> GetAll(SessionToken token);

        [OperationContract]
        bool IsUserAuthenticated(SessionToken token);

        [OperationContract]
        bool IsValidAdmin(SessionToken token);

        [OperationContract]
        bool LoginAdmin(SessionToken token);
        
        [OperationContract]
        void LogoutAdmin(SessionToken token);
        
        [OperationContract]
        SessionToken RequestSessionToken(User user);
    }
}
