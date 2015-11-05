using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Dao.Impl;
using FH.SEv.UFO.Server.DAO.Impl;

namespace FH.SEv.UFO.Server.Provider.Impl
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
