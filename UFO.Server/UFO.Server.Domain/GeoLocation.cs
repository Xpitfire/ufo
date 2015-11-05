using System;

namespace UFO.Server.Domain
{
    [Serializable]
    public class GeoLocation
    {
        public const double InvalidGeoLocation = double.MinValue;

        public double Longitude { get; set; } = InvalidGeoLocation;

        public double Latitude { get; set; } = InvalidGeoLocation;
    }
}
