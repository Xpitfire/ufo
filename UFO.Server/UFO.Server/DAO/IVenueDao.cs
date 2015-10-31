using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IVenueDao
    {
        DaoResponse<Venue> InsertVenue(Venue venue);

        DaoResponse<Venue> UpdateVenue(Venue venue);

        IList<Venue> GetAllVenues();

        IList<Venue> GetVenues<T>(Filter<User, string> filter);
    }
}