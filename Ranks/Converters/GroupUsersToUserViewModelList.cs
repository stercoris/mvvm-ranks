using Ranks.Models;
using Ranks.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ranks.Converters
{

    public class GroupUsersToUserViewModelList : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GroupViewModel groupvm = (value as GroupViewModel);
            List<User> users = groupvm.Group.Users;
            return (users.Select((user) => new UserViewModel(groupvm.groupsvm, user)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }
    
}
