using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IAgendaDao
    {
        DaoResponse<Agenda> InsertAgenda(Agenda agenda);

        IList<Agenda> GetAllAgendas();

        IList<Agenda> GetAgendas(Filter<Agenda, string> filter);
    }
}
