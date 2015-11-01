using System.Collections.Generic;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;

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

        public IList<Venue> GetVenues<T>(T criteria, Filter<Venue, T> filter)
        {
            throw new System.NotImplementedException();
        }
    }
}
