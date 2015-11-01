using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Dao.Impl;

namespace FH.SEv.UFO.Server.Provider.Impl
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
