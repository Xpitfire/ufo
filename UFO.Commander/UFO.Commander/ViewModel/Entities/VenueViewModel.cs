using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class VenueViewModel : Venue
    {
        public override string VenueId { get; set; }
        public new LocationViewModel Location { get; set; }
        public override string Name { get; set; }
    }
}
