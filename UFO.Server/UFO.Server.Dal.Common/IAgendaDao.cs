using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IAgendaDao
    {
        DaoResponse<Agenda> InsertAgenda(Agenda agenda);

        IList<Agenda> GetAllAgendas();

        IList<Agenda> GetAgendas<T>(T criteria, Filter<Agenda, T> filter);
    }
}
