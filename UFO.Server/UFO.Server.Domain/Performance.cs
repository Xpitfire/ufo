using System;

namespace UFO.Server.Domain
{
    [Serializable]
    public class Performance
    {
        public DateTime DateTime { get; set; }

        public Venue Venue { get; set; }

        public Artist Artist { get; set; }
    }
}
