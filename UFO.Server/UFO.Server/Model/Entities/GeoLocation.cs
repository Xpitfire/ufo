using System;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class GeoLocation
    {
        public const double InvalidGeoLocation = double.MinValue;

        public double Longitude { get; set; } = InvalidGeoLocation;

        public double Latitude { get; set; } = InvalidGeoLocation;
    }
}
