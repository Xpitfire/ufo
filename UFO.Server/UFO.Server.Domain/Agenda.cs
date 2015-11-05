using System;
using System.Collections.Generic;

namespace UFO.Server.Domain
{
    [Serializable]
    public class Agenda
    {
        public ISet<Performance> Performances => new HashSet<Performance>();
    }
}
