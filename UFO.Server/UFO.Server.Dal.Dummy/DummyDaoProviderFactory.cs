using UFO.Server.Dal.Common;

namespace UFO.Server.Dal.Dummy
{
    class DummyDaoProviderFactory : IDaoProviderFactory
    {
        public IAgendaDao CreateAgendaDao()
        {
            return new DummyAgendaDao();
        }

        public IArtistDao CreateArtistDao()
        {
            return new DummyArtistDao();
        }

        public IPerformanceDao CreatePerformanceDao()
        {
            return new DummyPerformanceDao();
        }

        public IUserDao CreateUserDao()
        {
            return new DummyUserDeo();
        }

        public IVenueDao CreateVenueDao()
        {
            return new DummyVenueDao();
        }
    }
}
