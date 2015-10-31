using System;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class Venue
    {
        public GeoLocation GeoLocation { get; set; }

        public string SpotId { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string Description { get; set; }
        
    }
}
