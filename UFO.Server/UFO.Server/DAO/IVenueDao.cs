using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IVenueDao
    {
        DaoResponse<Venue> InsertVenue(Venue venue);

        DaoResponse<Venue> UpdateVenue(Venue venue);

        IList<Venue> GetAllVenues();

        IList<Venue> GetVenues<T>(T criteria, Filter<Venue, T> filter);
    }
}