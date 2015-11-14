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
    class ArtistDao : IArtistDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public ArtistDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        private Artist CreateArtistObject(IDataReader dataReader)
        {
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
            return artist;
        }

        public DaoResponse<Artist> Delete(Artist artist)
        {
            throw new NotImplementedException();
        }
        
        public DaoResponse<IList<Artist>> GetAll()
        {
            var artists = new List<Artist>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAllArtists))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    artists.Add(CreateArtistObject(dataReader));
                }
            }
                
            return DaoResponse.QuerySuccessfull<IList<Artist>>(artists);
        }

        public DaoResponse<IList<Artist>> GetAllAndFilterBy<T>(T criteria, Filter<Artist, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Artist>>(
                new List<Artist>(filter.Invoke(GetAll().ResultObject, criteria)));
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