using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public interface IAgendaDao
    {
        DaoResponse<Agenda> InsertAgenda(Agenda agenda);

        IList<Agenda> GetAllAgendas();

        IList<Agenda> GetAgendas<T>(T criteria, Filter<Agenda, T> filter);
    }
}
