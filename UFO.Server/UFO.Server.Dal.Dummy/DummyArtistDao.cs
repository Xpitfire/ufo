using System.Collections.Generic;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class DummyArtistDao : IArtistDao
    {
        public DaoResponse<Artist> InsertArtist(Artist artist)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<Artist> UpdateArtist(Artist artist)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<Artist> DeleteArtist(Artist artist)
        {
            throw new System.NotImplementedException();
        }

        public IList<Artist> GetAllArtists()
        {
            throw new System.NotImplementedException();
        }

        public IList<Artist> GetArtists<T>(T criteria, Filter<Artist, T> filter)
        {
            throw new System.NotImplementedException();
        }
    }
}
