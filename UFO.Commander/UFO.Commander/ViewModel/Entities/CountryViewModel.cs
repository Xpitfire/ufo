using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class CountryViewModel : Country, INotifyPropertyChanged, IComparable<CountryViewModel>
    {
        public override string Code { get; set; }
        public override string Name { get; set; }

        public int CompareTo(CountryViewModel other)
        {
            return string.CompareOrdinal(Name, other.Name);
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
