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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class ArtistDao : IArtistDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        private const string EntityName = "artist";
        private const string EntityViewName = "artistview";

        public ArtistDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        private Artist CreateArtistObject(IDataReader dataReader)
        {
            var artist = new Artist
            {
                ArtistId = _dbCommProvider.CastDbObject<int>(dataReader, "ArtistId"),
                Name = _dbCommProvider.CastDbObject<string>(dataReader, "ArtistName"),
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
            return artist;
        }

        /// <summary>
        /// Unused due to WebService MaxSize exceed message.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private byte[] LoadImagesSource(string fileName)
        {
            if (fileName == null || fileName.Equals(string.Empty)) return null;
            var filePath = Path.Combine(Environment.CurrentDirectory, "images", fileName);
            if (!File.Exists(filePath)) return null;
            if (Path.GetExtension(filePath) != ".jpg") return null;

            var image = Image.FromFile(filePath);
            byte[] imageArray;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageArray = ms.ToArray();
            }
            return imageArray;
        }

        private Dictionary<string, QueryParameter> CreateArtistParameter(Artist artist)
        {
            return new Dictionary<string, QueryParameter>
            {
                {"?ArtistId", new QueryParameter {ParameterValue = artist.ArtistId}},
                {"?Name", new QueryParameter {ParameterValue = artist.Name}},
                {"?EMail", new QueryParameter {ParameterValue = artist.EMail}},
                {"?CategoryId", new QueryParameter {ParameterValue = artist.Category?.CategoryId}},
                {"?CountryCode", new QueryParameter {ParameterValue = artist.Country?.Code}},
                {"?Picture", new QueryParameter {ParameterValue = artist.Picture?.Path}},
                {"?PromoVideo", new QueryParameter {ParameterValue = artist.PromoVideo}}
            };
        }

        [DaoExceptionHandler(typeof(Artist))]
        public DaoResponse<Artist> Delete(Artist entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.DeleteArtist, CreateArtistParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }

        [DaoExceptionHandler(typeof(Artist))]
        public DaoResponse<Artist> SelectById(int id)
        {
            Artist artist = null;
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?ArtistId", new QueryParameter {ParameterValue = id}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectArtistById, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    artist = CreateArtistObject(dataReader);
                    //if (artist.Picture != null)
                    //    artist.Picture.DataStream = LoadImagesSource(artist.Picture.Path);
                }
            }

            return artist != null ? DaoResponse.QuerySuccessful(artist) : DaoResponse.QueryEmptyResult<Artist>();
        }

        [DaoExceptionHandler(typeof(List<Artist>))]
        public DaoResponse<List<Artist>> SelectByKeyword(string keyword)
        {
            var artists = new List<Artist>();
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Keyword", new QueryParameter {ParameterValue = $"%{keyword}%"}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectArtistByKeyword, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    var artist = CreateArtistObject(dataReader);
                    artists.Add(artist);
                    //if (artist.Picture != null)
                    //    artist.Picture.DataStream = LoadImagesSource(artist.Picture.Path);
                }
            }
            return artists.Any() ? DaoResponse.QuerySuccessful(artists) : DaoResponse.QueryEmptyResult<List<Artist>>();
        }

        [DaoExceptionHandler(typeof(List<Artist>))]
        public DaoResponse<List<Artist>> SelectAll()
        {
            var artists = new List<Artist>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectAll(EntityViewName)))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    var artist = CreateArtistObject(dataReader);
                    artists.Add(artist);
                    //if (artist.Picture != null)
                    //    artist.Picture.DataStream = LoadImagesSource(artist.Picture.Path);
                }
            }
            return artists.Any() ? DaoResponse.QuerySuccessful(artists) : DaoResponse.QueryEmptyResult<List<Artist>>();
        }

        [DaoExceptionHandler(typeof(List<Artist>))]
        public DaoResponse<List<Artist>> Select(PagingData page)
        {
            var artists = new List<Artist>();
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
                    var artist = CreateArtistObject(dataReader);
                    artists.Add(artist);
                    //if (artist.Picture != null)
                    //    artist.Picture.DataStream = LoadImagesSource(artist.Picture.Path);
                }
            }
            return artists.Any() ? DaoResponse.QuerySuccessful(artists) : DaoResponse.QueryEmptyResult<List<Artist>>();
        }

        [DaoExceptionHandler(typeof(Artist))]
        public DaoResponse<Artist> Insert(Artist entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.InsertArtist, CreateArtistParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
        }
        
        [DaoExceptionHandler(typeof(Artist))]
        public DaoResponse<Artist> Update(Artist entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateArtist, CreateArtistParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
            }
            return DaoResponse.QuerySuccessful(entity);
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