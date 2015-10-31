using System.Collections.Generic;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.DAO.Impl
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

        public IList<Artist> GetArtists(Filter<User, string> filter)
        {
            throw new System.NotImplementedException();
        }
    }
}
