using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IPerformanceDao
    {
        DaoResponse<Performance> UpdatePerformance(Performance performance);

        IList<Performance> GetAllPerformances();

        IList<Performance> GetPerformances<T>(T criteria, Filter<Performance, T> filter);
    }
}