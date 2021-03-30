using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.Converters
{

    public class ColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //start 209, 25, 25
            //finish 25, 209, 25
            double ratio = System.Convert.ToDouble(value) / System.Convert.ToDouble(DataAccess.DBProvider.DBContext.Ranks.Max((r) => r.Id));
            Color myColor;
            if (ratio <= 0.5)
            {
                myColor = Color.FromArgb(209, GetGreenPointByRatio(ratio, 25, 209), 25);
            }
            else
            {
                myColor = Color.FromArgb(GetRedPointByRatio(ratio, 25, 209), 209, 25);
            }
            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            return "#" + hex;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
        private int GetGreenPointByRatio(double ratio, int startPoint, int endPoint)
        {
            int length = endPoint - startPoint;
            int point = System.Convert.ToInt32(length * ratio);
            return point + startPoint;
        }
        private int GetRedPointByRatio(double ratio, int startPoint, int endPoint)
        {
            double length = ratio * (endPoint - startPoint);
            int point = System.Convert.ToInt32(length * ratio);
            return endPoint - System.Convert.ToInt32(length);//209->25
        }
    }

}
