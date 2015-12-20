using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class LocationViewModel : Location, INotifyPropertyChanged, IComparable<LocationViewModel>
    {
        public override int LocationId { get; set; }
        public override decimal Longitude { get; set; }
        public override decimal Latitude { get; set; }
        public override string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(LocationViewModel other)
        {
            return string.Compare(Name, other?.Name, StringComparison.Ordinal);
        }
    }
}
