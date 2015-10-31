using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.Dao.Impl
{
    class DummyAgendaDao : IAgendaDao
    {
        public DaoResponse<Agenda> InsertAgenda(Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public IList<Agenda> GetAllAgendas()
        {
            throw new NotImplementedException();
        }

        public IList<Agenda> GetAgendas(Filter<Agenda, string> filter)
        {
            throw new NotImplementedException();
        }
    }
}
