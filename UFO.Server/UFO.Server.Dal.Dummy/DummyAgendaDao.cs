using System;
using System.Collections.Generic;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
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

        public IList<Agenda> GetAgendas<T>(T criteria, Filter<Agenda, T> filter)
        {
            throw new NotImplementedException();
        }
    }
}
