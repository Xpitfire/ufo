using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class UserViewModel : User
    {
        public override int UserId { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string EMail { get; set; }
        public override string Password { get; set; }
        public override bool IsAdmin { get; set; }
        public override bool IsArtist { get; set; }
    }
}
