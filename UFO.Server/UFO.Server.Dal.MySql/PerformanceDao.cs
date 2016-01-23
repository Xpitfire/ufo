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
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class PerformanceDao : IPerformanceDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        private const string EntityName = "performance";
        private const string EntityViewName = "performanceview";

        public PerformanceDao(ADbCommProvider dbCommProvider)
        {
            _dbCommProvider = dbCommProvider;
        }
        
        private Performance CreatePerformanceObject(IDataReader dataReader)
        {
            var performance = new Performance
            {
                DateTime = (DateTime)dataReader["Date"]
            };

            var artist = new Artist
            {
                ArtistId = _dbCommProvider.CastDbObject<int>(dataReader, "ArtistId"),
                Name =  _dbCommProvider.CastDbObject<string>(dataReader, "ArtistName"),
                EMail = _dbCommProvider.CastDbObject<string>(dataReader, "EMail"),
                PromoVideo = _dbCommProvider.CastDbObject<string>(dataReader, "PromoVideo"),
                Picture = new BlobData
                {
                    Path = _dbCommProvider.CastDbObject<string>(dataReader, "Picture")
                },
                Country = new Country
                {
                    Code = _dbCommProvider.CastDbObject<string>(dataReader, "CountryCode"),
                    Name = _dbCommProvider.CastDbObject<string>(dataReader, "CountryName")
                }
            };
            if (!_dbCommProvider.IsDbNull(dataReader, "CategoryId"))
            {
                artist.Category = new Category
                {
                    CategoryId = _dbCommProvider.CastDbObject<string>(dataReader, "CategoryId"),
                    Name = _dbCommProvider.CastDbObject<string>(dataReader, "CategoryName"),
					Color = _dbCommProvider.CastDbObject<string>(dataReader, "CategoryColor")
                };
            }
            performance.Artist = artist;

            if (!_dbCommProvider.IsDbNull(dataReader, "VenueId"))
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
                performance.Venue = venue;
            }
            return performance;
        }

        private void VerifyPerformanceValue(Performance entity)
        {
            if (entity.DateTime.Minute != 0 || entity.DateTime.Second != 0 || entity.DateTime.Millisecond != 0)
            {
                throw new InvalidOperationException("Invalid Date format: Only full hours allowed!");
            }

            var fromTime = entity.DateTime.AddHours(-1);
            var toTime = entity.DateTime.AddHours(1);

            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?FromTime", new QueryParameter {ParameterValue = fromTime.ToString(Constants.CommonDateFormatFull)}},
                {"?ToTime", new QueryParameter {ParameterValue = toTime.ToString(Constants.CommonDateFormatFull)}},
                {"?ArtistId", new QueryParameter {ParameterValue = entity.Artist?.ArtistId}}
            };

            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectPerformanceBetweenHours, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    throw new InvalidOperationException("Invalid Date format: ArtistId already performing!");
                }
            }
        }

        private Dictionary<string, QueryParameter> CreatePerformanceParameter(Performance performance)
        {
            return new Dictionary<string, QueryParameter>
            {
                {"?Date", new QueryParameter {ParameterValue = performance.DateTime.ToString(Constants.CommonDateFormatFull)}},
                {"?ArtistId", new QueryParameter {ParameterValue = performance.Artist.ArtistId}},
                {"?VenueId", new QueryParameter {ParameterValue = performance.Venue.VenueId}}
            };
        }

        [DaoExceptionHandler(typeof(Performance))]
        public DaoResponse<Performance> Insert(Performance entity)
        {
            VerifyPerformanceValue(entity);
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.InsertPerformance, CreatePerformanceParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(Performance))]
        public DaoResponse<Performance> Update(Performance entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdatePerformance, CreatePerformanceParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(Performance))]
        public DaoResponse<Performance> Delete(Performance entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.DeletePerformance, CreatePerformanceParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(Performance))]
        public DaoResponse<Performance> SelectById(DateTime date, int artistId)
        {
            Performance performance = null;
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Date", new QueryParameter {ParameterValue = date.ToString(Constants.CommonDateFormatFull)}},
                {"?ArtistId", new QueryParameter {ParameterValue = artistId}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectPerformanceById, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    performance = CreatePerformanceObject(dataReader);
                }
            }
            return performance != null ? DaoResponse.QuerySuccessful(performance) : DaoResponse.QueryEmptyResult<Performance>();
        }

        [DaoExceptionHandler(typeof(List<Performance>))]
        public DaoResponse<List<Performance>> SelectByDate(DateTime date)
        {
            var performances = new List<Performance>();
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Date", new QueryParameter {ParameterValue = $"%{date.ToString(Constants.CommonDateFormatDay)}%"}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectPerformanceByDate, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }
            return performances.Any() ? DaoResponse.QuerySuccessful(performances) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }

        [DaoExceptionHandler(typeof(List<Performance>))]
        public DaoResponse<List<Performance>> SelectLastestPerformances()
        {
            var performances = new List<Performance>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectLatestPerformances))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }
            return performances.Any() ? DaoResponse.QuerySuccessful(performances) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }

        [DaoExceptionHandler(typeof(List<Performance>))]
        public DaoResponse<List<Performance>> SelectByArtistId(int artistId)
        {
            var performances = new List<Performance>();
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?ArtistId", new QueryParameter {ParameterValue = artistId}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectPerformanceByArtist, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }
            return performances.Any() ? DaoResponse.QuerySuccessful(performances) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }

        [DaoExceptionHandler(typeof(List<Performance>))]
        public DaoResponse<List<Performance>> SelectByVenueId(string venueId)
        {
            var performances = new List<Performance>();
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?VenueId", new QueryParameter {ParameterValue = venueId}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectPerformanceByVenue, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }
            return performances.Any() ? DaoResponse.QuerySuccessful(performances) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }

        [DaoExceptionHandler(typeof(List<Performance>))]
        public DaoResponse<List<Performance>> SelectByKeyword(string keyword)
        {
            var performances = new List<Performance>();
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Keyword", new QueryParameter {ParameterValue = $"%{keyword}%"}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectPerformanceByKeyword, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }
            return performances.Any() ? DaoResponse.QuerySuccessful(performances) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }

        [DaoExceptionHandler(typeof(List<Performance>))]
        public DaoResponse<List<Performance>> SelectAll()
        {
            var performances = new List<Performance>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAll(EntityViewName)))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }
            return performances.Any() ? DaoResponse.QuerySuccessful(performances) : DaoResponse.QueryEmptyResult<List<Performance>>();
        }

        [DaoExceptionHandler(typeof(List<Performance>))]
        public DaoResponse<List<Performance>> Select(PagingData page)
        {
            var locations = new List<Performance>();
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Offset", new QueryParameter {ParameterValue = page.Offset}},
                {"?Request", new QueryParameter {ParameterValue = page.Request}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectLimit(EntityViewName), parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    locations.Add(CreatePerformanceObject(dataReader));
                }
            }
            return locations.Any() ? DaoResponse.QuerySuccessful(locations) : DaoResponse.QueryEmptyResult<List<Performance>>();
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