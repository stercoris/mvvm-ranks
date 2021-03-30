using Order.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.Converters
{

    public class TopUsersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var UsersList = (value as ObservableCollection<UserViewModel>).ToList();
            UsersList = UsersList.OrderBy(user => System.Convert.ToInt32(user.User.Rank.Id)).Reverse().ToList();
            var topUsers = new ObservableCollection<UserViewModel>();
            foreach (var user in UsersList.GetRange(0, (UsersList.Count > 3) ? 3 : UsersList.Count))
            {
                topUsers.Add(user);
            }
            return topUsers;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}
