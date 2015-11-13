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
using System;
using System.Collections.Generic;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class ArtistDao : IArtistDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public ArtistDao(ADbCommProvider dbCommProvider)
        {
            _dbCommProvider = dbCommProvider;
        }

        public DaoResponse<Artist> Delete(Artist artist)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<IList<Artist>> GetAll()
        {
            throw new NotImplementedException();
        }

        public DaoResponse<IList<Artist>> Get<T>(T criteria, Filter<Artist, T> filter)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Artist> Insert(Artist artist)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Artist> Update(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}