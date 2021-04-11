using System;
using System.Globalization;
using System.Windows.Data;

namespace Order.WPF.Converters
{

    public class EditStateToArrowAngleConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null ? 180 : 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}
