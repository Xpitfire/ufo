using System;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class Performance
    {
        public DateTime DateTime { get; set; }

        public Venue Venue { get; set; }

        public Artist Artist { get; set; }
    }
}
