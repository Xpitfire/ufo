using System.Collections.Generic;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.DAO.Impl
{
    class DummyPerformanceDao : IPerformanceDao
    {
        public DaoResponse<Performance> UpdatePerformance(Performance performance)
        {
            throw new System.NotImplementedException();
        }

        public IList<Performance> GetAllPerformances()
        {
            throw new System.NotImplementedException();
        }

        public IList<Performance> GetPerformances(Filter<User, string> filter)
        {
            throw new System.NotImplementedException();
        }
    }
}
