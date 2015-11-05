using System.Collections.Generic;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    public class DbPerformanceDao : IPerformanceDao
    {
        public DaoResponse<Performance> UpdatePerformance(Performance performance)
        {
            throw new System.NotImplementedException();
        }

        public IList<Performance> GetAllPerformances()
        {
            throw new System.NotImplementedException();
        }

        public IList<Performance> GetPerformances<T>(T criteria, Filter<Performance, T> filter)
        {
            throw new System.NotImplementedException();
        }
    }
}