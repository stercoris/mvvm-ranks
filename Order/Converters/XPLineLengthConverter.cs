using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.WPF.Converters
{

    public class XPLineLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double length = 1;
            if (System.Convert.ToDouble(value) > 1)
                length = (System.Convert.ToDouble(value)-1) * 80 + 11;
            else
                length = 0;
            Trace.WriteLine(length);
            return length;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}

