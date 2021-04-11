using System.Globalization;
using System.Windows.Data;
using System;
using System.Linq;

namespace Order.WPF.Converters
{

    public class GroupListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var groupsNames = DataAccess.DBProvider.DBContext.Groups.ToList();
              //  .Select(group => group.Name).ToList();
            return groupsNames;
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

