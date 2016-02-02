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
                var dateStr = $"{Date.ToString("dd-MM-yyyy")} {_hour}";
                DateTime = DateTime.ParseExact(dateStr, Format, CultureInfo.InvariantCulture);
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                var dateStr = $"{_date.ToString("dd-MM-yyyy")} {Hour}";
                DateTime = DateTime.ParseExact(dateStr, Format, CultureInfo.InvariantCulture);
            }
        }
        
        public DateTimeViewModel(DateTime dateTime)
        {
            this.DateTime = dateTime;
            _hour = dateTime.ToString("HH:mm");
            _date = dateTime;
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

        public static implicit operator DateTime(DateTimeViewModel dateTimeViewModel)
        {
            return dateTimeViewModel.DateTime;
        }

        public static implicit operator DateTimeViewModel(DateTime dateTime)
        {
            return new DateTimeViewModel(dateTime);
        }
    }
}
