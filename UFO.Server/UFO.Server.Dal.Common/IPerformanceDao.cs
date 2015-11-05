using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public interface IPerformanceDao
    {
        DaoResponse<Performance> UpdatePerformance(Performance performance);

        IList<Performance> GetAllPerformances();

        IList<Performance> GetPerformances<T>(T criteria, Filter<Performance, T> filter);
    }
}