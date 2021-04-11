using System.Globalization;
using System.Windows.Data;
using System;
using System.Linq;

namespace Order.WPF.Converters
{

    public class RankListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Ranks = DataAccess.DBProvider.DBContext.Ranks.ToList();
            //  .Select(group => group.Name).ToList();
            return Ranks;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string groupName = value.ToString();
            var foundedGroup = DataAccess.DBProvider.DBContext.Groups
                               .Single(group => group.Name == groupName);
            return (value);
        }
    }

}

