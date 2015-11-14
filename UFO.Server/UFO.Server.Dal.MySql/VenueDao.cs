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
    class VenueDao : IVenueDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public VenueDao(ADbCommProvider dbCommProvider)
        {
            _dbCommProvider = dbCommProvider;
        }

        public DaoResponse<Venue> Insert(Venue venue)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Venue> Update(Venue venue)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<IList<Venue>> GetAll()
        {
            var venues = new List<Venue>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAllVenues))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    venues.Add(CreateVenueObject(dataReader));
                }
            }

            return DaoResponse.QuerySuccessfull<IList<Venue>>(venues);
        }

        private Venue CreateVenueObject(IDataReader dataReader)
        {
            var venue = new Venue
            {
                VenueId = (string)dataReader["VenueId"],
                Name = (string)dataReader["VenueName"],
                Location = new Location
                {
                    LocationId = (int)dataReader["LocationId"],
                    Name = (string)dataReader["LocationName"],
                    Latitude = (decimal)dataReader["Latitude"],
                    Longitude = (decimal)dataReader["Longitude"]
                }
            };
            return venue;
        }

        public DaoResponse<IList<Venue>> GetAllAndFilterBy<T>(T criteria, Filter<Venue, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Venue>>(
                new List<Venue>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}