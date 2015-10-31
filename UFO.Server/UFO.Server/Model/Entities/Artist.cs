using System;
using System.Collections.Generic;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class Artist
    {
        public const int InvalidArtistId = int.MinValue;

        public int ArtistId { get; set; } = Artist.InvalidArtistId;

        public string Name { get; set; }

        public string EMail { get; set; }

        public int CategoryId { get; set; } = Category.InvalidCategoryId;

        public Country Country { get; set; }

        public BinDataStream Picture { get; set; }

        public BinDataStream PromoVideo { get; set; }

        public ISet<User> ArtistList => new HashSet<User>();
    }
}
