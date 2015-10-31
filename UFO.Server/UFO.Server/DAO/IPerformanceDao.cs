using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IPerformanceDao
    {
        DaoResponse<Performance> UpdatePerformance(Performance performance);

        IList<Performance> GetAllPerformances();

        IList<Performance> GetPerformances(Filter<User, string> filter);
    }
}