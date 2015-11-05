using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UFO.Server.Domain
{
    [Serializable]
    public class Artist
    {
        public const int InvalidArtistId = int.MinValue;

        public int ArtistId { get; set; } = Artist.InvalidArtistId;

        public string Name { get; set; }

        [RegularExpression(Constants.EMailRegex)]
        public string EMail { get; set; }

        public int CategoryId { get; set; } = Category.InvalidCategoryId;

        public Country Country { get; set; }

        public BlobData Picture { get; set; }

        public string PromoVideo { get; set; }

        public ISet<User> ArtistList => new HashSet<User>();
    }
}
