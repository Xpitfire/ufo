using PostSharp.Patterns.Model;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class LocationViewModel : Location
    {
        public override int LocationId { get; set; }
        public override decimal Longitude { get; set; }
        public override decimal Latitude { get; set; }
        public override string Name { get; set; }
    }
}
