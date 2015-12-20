using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class CategoryViewModel : Category, INotifyPropertyChanged, IComparable<CategoryViewModel>
    {
        public override string CategoryId { get; set; }
        public override string Name { get; set; }
        public override string Color { get; set; }

        public int CompareTo(CategoryViewModel other)
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
