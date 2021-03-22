using RanksClient.Models;
using Ranks.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using RanksClient;

namespace Ranks.Converters
{

    public class GroupUsersToUserViewModelList : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GroupViewModel groupvm = (value as GroupViewModel);
            if (groupvm != null)
            {
                List<User> users = groupvm.Group.Users;
                var api = new API("http://localhost:8000/graph");
                return (users.Select(async (user) =>
                {
                    user.Picture = await api.UserResolver.GetImg("9");
                    Console.WriteLine(user.Picture);
                    return (new UserViewModel(groupvm.groupsvm, user));
                }));
            }
            else
            {
                return new List <UserViewModel>{ };
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }
    
}
