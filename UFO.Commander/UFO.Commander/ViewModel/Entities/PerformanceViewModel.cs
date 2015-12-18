using System;
using PostSharp.Patterns.Model;
using UFO.Commander.Helper;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class PerformanceViewModel : Performance
    {
        public override DateTime DateTime { get; set; }
        public override Artist Artist { get; set; }
        public override Venue Venue { get; set; }

        [SafeForDependencyAnalysis]
        public virtual ArtistViewModel ArtistViewModel => Artist?.ToViewModelObject<ArtistViewModel>();

        [SafeForDependencyAnalysis]
        public virtual VenueViewModel VenueViewModel => Venue?.ToViewModelObject<VenueViewModel>();
        
    }
}
