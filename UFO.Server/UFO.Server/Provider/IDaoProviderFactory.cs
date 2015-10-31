using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FH.SEv.UFO.Server.Dao;

namespace FH.SEv.UFO.Server.Provider
{
    public interface IDaoProviderFactory
    {
        IAgendaDao CreateAgendaDao();

        IArtistDao CreateArtistDao();

        IPerformanceDao CreatePerformanceDao();

        IUserDao CreateUserDao();

        IVenueDao CreateVenueDao();
    }
}
