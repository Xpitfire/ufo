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
using System.Linq.Expressions;
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

        private Venue CreateVenueObject(IDataReader dataReader)
        {
            var venue = new Venue
            {
                VenueId = _dbCommProvider.CastDbObject<string>(dataReader, "VenueId"),
                Name = _dbCommProvider.CastDbObject<string>(dataReader, "VenueName"),
                Location = new Location
                {
                    LocationId = _dbCommProvider.CastDbObject<int>(dataReader, "LocationId"),
                    Name = _dbCommProvider.CastDbObject<string>(dataReader, "LocationName"),
                    Latitude = _dbCommProvider.CastDbObject<decimal>(dataReader, "Latitude"),
                    Longitude = _dbCommProvider.CastDbObject<decimal>(dataReader, "Longitude")
                }
            };
            return venue;
        }

        [DaoExceptionHandler(typeof(Venue))]
        public DaoResponse<Venue> Insert(Venue entity)
        {
            var paramter = new Dictionary<string, QueryParameter>
            {
                {"?VenueId", new QueryParameter {ParameterValue = entity.VenueId}},
                {"?LocationId", new QueryParameter {ParameterValue = entity.Location?.LocationId}},
                {"?Name", new QueryParameter {ParameterValue = entity.Name}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateUser, paramter))
            {
                _dbCommProvider.ExecuteNonQuery(command);
                return DaoResponse.QuerySuccessful(entity);
            }
        }

        [DaoExceptionHandler(typeof(Venue))]
        public DaoResponse<Venue> Update(Venue entity)
        {
            throw new NotImplementedException();
        }

        [DaoExceptionHandler(typeof(Venue))]
        public DaoResponse<Venue> Delete(Venue entity)
        {
            throw new NotImplementedException();
        }

        [DaoExceptionHandler(typeof(IList<Venue>))]
        public DaoResponse<IList<Venue>> SelectAll()
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

            return DaoResponse.QuerySuccessful<IList<Venue>>(venues);
        }

        [DaoExceptionHandler(typeof(IList<Venue>))]
        public DaoResponse<IList<Venue>> SelectWhere<T>(T criteria, Expression<Filter<Venue, T>> filterExpression)
        {
            return DaoResponse.QuerySuccessful<IList<Venue>>(
                new List<Venue>(filterExpression.Compile()(SelectAll().ResultObject, criteria)));
        }
    }
}