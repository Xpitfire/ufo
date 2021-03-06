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
using UFO.Server.Dal.Common;

namespace UFO.Server.Dal.Dummy
{
    class DaoProviderFactory : IDaoProviderFactory
    {
        public IArtistDao CreateArtistDao()
        {
            return new ArtistDao();
        }

        public IPerformanceDao CreatePerformanceDao()
        {
            return new PerformanceDao();
        }

        public IUserDao CreateUserDao()
        {
            return new UserDeo();
        }

        public IVenueDao CreateVenueDao()
        {
            return new VenueDao();
        }

        public ICategoryDao CreateCategoryDao()
        {
            return new CategoryDao();
        }

        public ICountryDao CreateCountryDao()
        {
            return new CountryDao();
        }

        public ILocationDao CreateLocationDao()
        {
            throw new System.NotImplementedException();
        }
    }
}
