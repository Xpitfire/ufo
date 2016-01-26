using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        public const string Format = "dd-MM-yyyy HH:mm";

        public DateTime DateTime { get; set; }

        private string _hour;
        public string Hour
        {
            get { return _hour; }
            set
            {
                _hour = value;
                DateTime = DateTime.ParseExact($"{Date} {Hour}", Format, CultureInfo.InvariantCulture);
            }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                DateTime = DateTime.ParseExact($"{Date} {Hour}", Format, CultureInfo.InvariantCulture);
            }
        }
        
        public DateTimeViewModel(DateTime dateTime)
        {
            this.DateTime = dateTime;
            _hour = dateTime.ToString("HH:mm");
            _date = dateTime.ToString("dd-MM-yyyy");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Hour;
        }
    }
}
