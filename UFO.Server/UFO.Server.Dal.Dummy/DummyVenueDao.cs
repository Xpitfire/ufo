﻿using System.Collections.Generic;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
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
