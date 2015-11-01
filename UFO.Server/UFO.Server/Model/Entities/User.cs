using System;
using System.ComponentModel.DataAnnotations;
using FH.SEv.UFO.Server.Model.Helper;

namespace FH.SEv.UFO.Server.Model.Entities
{
    [Serializable]
    public class User
    {
        public int ArtistId { get; set; } = Artist.InvalidArtistId;

        public string FistName { get; set; }

        public string LastName { get; set; }

        [RegularExpression(Constants.EMailRegex)]
        public string EMail { get; set; }
        
        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsArtist { get; set; }

        public override int GetHashCode()
        {
            var hashCode = ArtistId;
            hashCode += FistName?.GetHashCode() ?? 0;
            hashCode += LastName?.GetHashCode() ?? 0;
            hashCode += EMail?.GetHashCode() ?? 0;
            hashCode += PasswordHash?.GetHashCode() ?? 0;
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null && (ArtistId == user.ArtistId && EMail == user.EMail);
        }

        public override string ToString()
        {
            return $"User ( ArtistId={ArtistId}, FirstName={FistName}, LastName={LastName}, EMail={EMail} )";
        }
    }
}
