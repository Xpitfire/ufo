using System;
using System.Collections.Generic;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    public class DbArtistDao : IArtistDao
    {
        public DaoResponse<Artist> DeleteArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public IList<Artist> GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public IList<Artist> GetArtists<T>(T criteria, Filter<Artist, T> filter)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Artist> InsertArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Artist> UpdateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}