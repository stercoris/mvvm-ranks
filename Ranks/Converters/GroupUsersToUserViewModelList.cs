using Ranks.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using RanksClient;
using System.Threading;

namespace Ranks.Converters
{
   
    public class GroupUsersToUserViewModelList : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            GroupViewModel groupvm = (value as GroupViewModel);
            if (groupvm != null)
            {
                //var userViewModels = (users.Select((user) => new UserViewModel(groupvm.groupsvm, user)));

                //return userViewModels;
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
