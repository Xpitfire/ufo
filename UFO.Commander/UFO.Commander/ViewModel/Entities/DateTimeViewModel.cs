using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;
using UFO.Commander.Annotations;

namespace UFO.Commander.ViewModel.Entities
{
    [NotifyPropertyChanged]
    public class DateTimeViewModel : INotifyPropertyChanged
    {
        public DateTime DateTime { get; set; }

        public DateTimeViewModel(DateTime dateTime)
        {
            this.DateTime = dateTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return DateTime.ToString("HH:mm");
        }
    }
}
