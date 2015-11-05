using System;
using UFO.Server.Dal.Common;

namespace UFO.Server.Dal.MySql
{
    class DbDaoProviderFactory : IDaoProviderFactory
    {
        

        public IAgendaDao CreateAgendaDao()
        {
            return new DbAgendaDao();
        }

        public IArtistDao CreateArtistDao()
        {
            return new DbArtistDao();
        }

        public IPerformanceDao CreatePerformanceDao()
        {
            return new DbPerformanceDao();
        }

        public IUserDao CreateUserDao()
        {
            return new DbUserDao();
        }

        public IVenueDao CreateVenueDao()
        {
            return new DbVenueDao();
        }
    }
}
