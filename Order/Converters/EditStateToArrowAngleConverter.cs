using System;
using System.Globalization;
using System.Windows.Data;

namespace Order.Converters
{

    public class EditStateToArrowAngleConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return (180);
            return (0);
        }

        //SelectedGroup = new List<UserViewModel>(
        //  group.Group.Users.Select(user => new UserViewModel(this, user))
        //);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}
