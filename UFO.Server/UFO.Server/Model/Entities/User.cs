using System;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class User
    {
        public string FistName { get; set; }

        public string LastName { get; set; }

        public string EMail { get; set; }

        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsArtist { get; set; }

        public int ArtistId { get; set; } = Artist.InvalidArtistId;
    }
}
