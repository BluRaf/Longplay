using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Longplay.Converters
{
    public class TimeSpanToDoubleConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan) value).TotalSeconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TimeSpan.FromSeconds((double) value);
        }
    }
}