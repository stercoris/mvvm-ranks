using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Ranks.ViewModels;

namespace Ranks.Converters
{

    public class TopUsersConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var UsersList = (value as ObservableCollection<UserViewModel>).ToList();
            UsersList = UsersList.OrderBy(user => System.Convert.ToInt32(user.User.rankId)).Reverse().ToList();
            var topUsers = new ObservableCollection<UserViewModel>();
            foreach (var user in UsersList.GetRange(0   , (UsersList.Count > 3) ? 3: UsersList.Count))
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
