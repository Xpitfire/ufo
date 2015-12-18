using PostSharp.Patterns.Model;
using UFO.Commander.Helper;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class VenueViewModel : Venue
    {
        public override string VenueId { get; set; }
        public override string Name { get; set; }
        public override Location Location { get; set; }

        [SafeForDependencyAnalysis]
        public virtual LocationViewModel LocationViewModel => Location?.ToViewModelObject<LocationViewModel>();
    }
}
