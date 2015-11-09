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
using UFO.Server.Dal.Common;

namespace UFO.Server.Dal.MySql
{
    class DaoProviderFactory : IDaoProviderFactory
    {
        private readonly ADbCommProvider _dbCommProvider;

        public DaoProviderFactory()
        {
            _dbCommProvider = new MySqlDbCommProvider();
        }

        public IAgendaDao CreateAgendaDao()
        {
            return new MySqlAgendaDao(_dbCommProvider);
        }

        public IArtistDao CreateArtistDao()
        {
            return new MySqlArtistDao(_dbCommProvider);
        }

        public IPerformanceDao CreatePerformanceDao()
        {
            return new MySqlPerformanceDao(_dbCommProvider);
        }

        public IUserDao CreateUserDao()
        {
            return new MySqlUserDao(_dbCommProvider);
        }

        public IVenueDao CreateVenueDao()
        {
            return new MySqlVenueDao(_dbCommProvider);
        }
    }
}
