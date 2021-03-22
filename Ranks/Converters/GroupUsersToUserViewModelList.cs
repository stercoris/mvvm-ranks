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
using RanksClient.Resolvers;
using System.Threading;

namespace Ranks.Converters
{
   
    public class GroupUsersToUserViewModelList : IValueConverter
    {

        public  object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GroupViewModel groupvm = (value as GroupViewModel);
            if (groupvm != null)
            {
                List<User> users = groupvm.Group.Users;
                var api = new API("http://localhost:8000/graph");
                var userViewModels = (users.Select((user) => new UserViewModel(groupvm.groupsvm, user)));
                new Thread(async () =>
                {
                    List<UsersImg> usersImg = await api.UserResolver.GetImg(groupvm.Group.Id.ToString());
                    foreach(var uservm in userViewModels)
                    {
                        uservm.User.Picture = usersImg.Find(user=>user.id==uservm.User.Id.ToString()).picture;
                    }
                }).Start();
                
                return userViewModels;
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
