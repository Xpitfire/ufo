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
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using MySql.Data.MySqlClient;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class LocationDao : ILocationDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        private const string EntityName = "location";

        public LocationDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        private Location CreateLocationObject(IDataReader dataReader)
        {
            var location = new Location
            {
                LocationId = _dbCommProvider.CastDbObject<int>(dataReader, "LocationId"),
                Longitude = _dbCommProvider.CastDbObject<decimal>(dataReader, "Longitude"),
                Latitude = _dbCommProvider.CastDbObject<decimal>(dataReader, "Latitude"),
                Name = _dbCommProvider.CastDbObject<string>(dataReader, "Name")

            };
            return location;
        }

        private Dictionary<string, QueryParameter> CreateLocationParameter(Location entity)
        {
            return new Dictionary<string, QueryParameter>
            {
                {"?LocationId", new QueryParameter {ParameterValue = entity.LocationId}},
                {"?Name", new QueryParameter {ParameterValue = entity.Name}},
                {"?Longitude", new QueryParameter {ParameterValue = entity.Longitude}},
                {"?Latitude", new QueryParameter {ParameterValue = entity.Latitude}}
            };
        }

        [DaoExceptionHandler(typeof(Location))]
        public DaoResponse<Location> SelectById(int id)
        {
            Location location = null;
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?LocationId", new QueryParameter {ParameterValue = id}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectLocationById, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    location = CreateLocationObject(dataReader);
                }
            }
            return location != null ? DaoResponse.QuerySuccessful(location) : DaoResponse.QueryEmptyResult<Location>();
        }

        [DaoExceptionHandler(typeof(Location))]
        public DaoResponse<Location> Insert(Location entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.InsertLocation, CreateLocationParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(Location))]
        public DaoResponse<Location> Update(Location entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateLocation, CreateLocationParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }
        
        [DaoExceptionHandler(typeof(Location))]
        public DaoResponse<Location> Delete(Location entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.DeleteLocation, CreateLocationParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(List<Location>))]
        public DaoResponse<List<Location>> SelectAll()
        {
            var locations = new List<Location>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand<MySqlDbType>(connection, SqlQueries.SelectAll(EntityName)))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    locations.Add(CreateLocationObject(dataReader));
                }
            }
            return locations.Any() ? DaoResponse.QuerySuccessful(locations) : DaoResponse.QueryEmptyResult<List<Location>>();
        }

        [DaoExceptionHandler(typeof(List<Location>))]
        public DaoResponse<List<Location>> Select(PagingData page)
        {
            var locations = new List<Location>();
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Offset", new QueryParameter {ParameterValue = page.Offset}},
                {"?Request", new QueryParameter {ParameterValue = page.Request}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectLimit(EntityName), parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    locations.Add(CreateLocationObject(dataReader));
                }
            }
            return locations.Any() ? DaoResponse.QuerySuccessful(locations) : DaoResponse.QueryEmptyResult<List<Location>>();
        }

        [DaoExceptionHandler(typeof(long))]
        public DaoResponse<long> Count()
        {
            var size = 0L;
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.Count(EntityName)))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    size = _dbCommProvider.CastDbObject<long>(dataReader, 0);
                }
            }
            return DaoResponse.QuerySuccessful(size);
        }
    }
}