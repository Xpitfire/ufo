using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class PerformanceViewModel : Performance, INotifyPropertyChanged, IComparable<PerformanceViewModel>
    {
        public override DateTime DateTime { get; set; }
        public override Artist Artist { get; set; }
        public override Venue Venue { get; set; }
        
        [SafeForDependencyAnalysis]
        public virtual DateTimeViewModel DateTimeViewModel
        {
            get { return new DateTimeViewModel(DateTime); }
            set
            {
                DateTime = value.DateTime;
                DateTimeViewModel.DateTime = value.DateTime;
            }
        }

        [SafeForDependencyAnalysis]
        public virtual ArtistViewModel ArtistViewModel
        {
            get { return Artist?.ToViewModelObject<ArtistViewModel>(); }
            set { Artist = value?.ToDomainObject<Artist>(); }
        }

        [SafeForDependencyAnalysis]
        public virtual VenueViewModel VenueViewModel
        {
            get { return Venue?.ToViewModelObject<VenueViewModel>(); }
            set { Venue = value?.ToDomainObject<Venue>(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CompareTo(PerformanceViewModel other)
        {
            return VenueViewModel.CompareTo(other.VenueViewModel) 
                + ArtistViewModel.CompareTo(other.ArtistViewModel);
        }

    }
}
