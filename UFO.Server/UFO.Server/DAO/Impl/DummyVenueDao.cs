using System.Collections.Generic;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.DAO.Impl
{
    class DummyVenueDao : IVenueDao
    {
        public DaoResponse<Venue> InsertVenue(Venue venue)
        {
            throw new System.NotImplementedException();
        }

        public DaoResponse<Venue> UpdateVenue(Venue venue)
        {
            throw new System.NotImplementedException();
        }

        public IList<Venue> GetAllVenues()
        {
            throw new System.NotImplementedException();
        }

        public IList<Venue> GetVenues<T>(Filter<User, string> filter)
        {
            throw new System.NotImplementedException();
        }
    }
}
