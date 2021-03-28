using RanksClient;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = RanksApi.IGetGroupGQL.Response.GroupSelection.UserSelection;

namespace Ranks.DataAccess
{
    class UsersStorage
    {
        [Reactive] public static ObservableCollection<User> Users { get; private set; }
        private static async Task<ObservableCollection<User>> StartLoading(int groupId)
        {
            var result = await RanksApi.IGetGroupGQL.SendQueryAsync(
                API.Client, 
                new RanksApi.IGetGroupGQL.Variables {
                    id = groupId 
                }
            );
            Users = new ObservableCollection<User>(result.Data.Group.users);
            return await Task.FromResult(Users);
        }


        private static Task UserLoading;
        public static async Task<ObservableCollection<User>> LoadUsers(int groupId)
        {
            if (UserLoading != null &&
                (
                    UserLoading.Status == TaskStatus.RanToCompletion ||
                    UserLoading.Status == TaskStatus.Running
                )
            )
            {
                UserLoading.Dispose();
            }

            UserLoading = StartLoading(groupId);
            await UserLoading;
            var result = await Task.FromResult(Users);
            return (result);
        }

    }
}
