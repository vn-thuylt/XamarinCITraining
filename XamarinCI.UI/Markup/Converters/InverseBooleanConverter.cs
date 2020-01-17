using System;
using System.Globalization;
using Xamarin.Forms;
using System.Collections;

namespace XamarinCI.UI.Markup.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        public static InverseBooleanConverter Instance = new InverseBooleanConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = value as bool?;
            return !b.HasValue || !b.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = value as bool?;
            if (!b.HasValue)
                return null;
            return !b.Value;
        }
    }
}
