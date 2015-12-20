using System;
using System.Collections.Generic;
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
    public class VenueViewModel : Venue, INotifyPropertyChanged, IComparable<VenueViewModel>
    {
        public override string VenueId { get; set; }
        public override string Name { get; set; }
        public override Location Location { get; set; }

        [SafeForDependencyAnalysis]
        public virtual LocationViewModel LocationViewModel
        {
            get { return Location?.ToViewModelObject<LocationViewModel>(); }
            set { Location = value?.ToDomainObject<Location>(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CompareTo(VenueViewModel other)
        {
            return string.Compare(Name, other?.Name, StringComparison.Ordinal);
        }
    }
}
