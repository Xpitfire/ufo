using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UFO.Commander.ViewModel;
using UFO.Commander.ViewModel.Entities;

namespace UFO.Commander.Converters
{
    public class TimeSlotPerformanceViewModelToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timeSlot = value as PerformanceOverviewViewModel.TimeSlotPerformanceViewModel;
            return (timeSlot == null || !Equals(parameter, timeSlot.TimeKey)) ? "+" : timeSlot.PerformanceViewModel?.Artist?.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Not required for OneWay binding
            throw new NotImplementedException();
        }
    }
}
