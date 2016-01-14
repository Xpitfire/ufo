using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UFO.Commander.Properties;

namespace UFO.Commander.Converters
{
    public class NullToImageSourceConverter : IValueConverter
    {
        private static readonly BitmapImage Placeholder = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, Resources.Placeholder)));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value ?? Placeholder;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
