using System;
using UFO.Server.Dal.Common;

namespace UFO.Server.Dal.MySql
{
    class DbDaoProviderFactory : IDaoProviderFactory
    {
        public IAgendaDao CreateAgendaDao()
        {
            throw new NotImplementedException();
        }

        public IArtistDao CreateArtistDao()
        {
            throw new NotImplementedException();
        }

        public IPerformanceDao CreatePerformanceDao()
        {
            throw new NotImplementedException();
        }

        public IUserDao CreateUserDao()
        {
            return new DbUserDao();
        }

        public IVenueDao CreateVenueDao()
        {
            throw new NotImplementedException();
        }
    }
}
