using System;
using System.Collections.Generic;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class Agenda
    {
        public ISet<Performance> Performances => new HashSet<Performance>();
    }
}
