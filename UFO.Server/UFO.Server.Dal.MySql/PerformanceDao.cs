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
    class PerformanceDao : IPerformanceDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public PerformanceDao(ADbCommProvider dbCommProvider)
        {
            _dbCommProvider = dbCommProvider;
        }

        public DaoResponse<Performance> Update(Performance performance)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<IList<Performance>> GetAll()
        {
            var performances = new List<Performance>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAllPerfomances))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    performances.Add(CreatePerformanceObject(dataReader));
                }
            }

            return DaoResponse.QuerySuccessfull<IList<Performance>>(performances);
        }

        private Performance CreatePerformanceObject(IDataReader dataReader)
        {
            var performance = new Performance
            {
                DateTime = (DateTime)dataReader["Date"]
            };

            var artist = new Artist
            {
                ArtistId = (int)dataReader["ArtistId"],
                Name = dataReader["ArtistName"] is DBNull ? null : (string)dataReader["ArtistName"],
                EMail = (string)dataReader["EMail"],
                PromoVideo = dataReader["PromoVideo"] is DBNull ? null : (string)dataReader["PromoVideo"],
                Picture = dataReader["Picture"] is DBNull ? null : BlobData.CreateBlobData((string)dataReader["Picture"]),
                Country = new Country
                {
                    Code = (string)dataReader["CountryCode"],
                    Name = (string)dataReader["CountryName"]
                }
            };
            if (!(dataReader["CategoryId"] is DBNull))
            {
                artist.Category = new Category
                {
                    CategoryId = (string)dataReader["CategoryId"],
                    Name = (string)dataReader["CategoryName"]
                };
            }
            performance.Artist = artist;

            if (!(dataReader["VenueId"] is DBNull))
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
                performance.Venue = venue;
            }
            
            return performance;
        }

        public DaoResponse<IList<Performance>> GetAllAndFilterBy<T>(T criteria, Filter<Performance, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Performance>>(
                new List<Performance>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}