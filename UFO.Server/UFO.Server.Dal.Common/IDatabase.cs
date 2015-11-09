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

namespace UFO.Server.Dal.Common
{
    public interface IDatabase
    {
        DbCommand CreateCommand(string commandText);
        int DeclareParameter(DbCommand command, string name, DbType type);
        void SetParameter(DbCommand command, string name, object value);
        void DefineParameter(DbCommand command, string name, DbType type, object value);

        IDataReader ExecuteReader(DbCommand command);
        int ExecuteNonQuery(DbCommand command);
    }
}
