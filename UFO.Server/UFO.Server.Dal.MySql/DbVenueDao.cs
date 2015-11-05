using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    [Serializable]
    public class DbVenueDao : IVenueDao
    {
        public DaoResponse<Venue> InsertVenue(Venue venue)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Venue> UpdateVenue(Venue venue)
        {
            throw new NotImplementedException();
        }

        public IList<Venue> GetAllVenues()
        {
            throw new NotImplementedException();
        }

        public IList<Venue> GetVenues<T>(T criteria, Filter<Venue, T> filter)
        {
            throw new NotImplementedException();
        }
    }
}