using RanksClient;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using User = RanksApi.IGetGroupGQL.Response.GroupSelection.UserSelection;
using Group = RanksApi.IGetGroupsGQL.Response.GroupSelection;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ranks.ViewModels
{
    class GroupViewModel : ReactiveObject
    {
        [Reactive] public Group Group { get; set; }

        // Каллбек для фетча пользователей группы
        [Reactive] public ICommand ShowUsersCommand { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }


        public GroupViewModel(
            Group group,
            ICommand groupSelectCommand,
            ICommand groupEditCommand
        )
        {
            this.Group = group;
            EditCommand = groupEditCommand;
            ShowUsersCommand = groupSelectCommand;
        }

        #region Users Loading
        private Task GroupLoading { get; set; }
        [Reactive] public ObservableCollection<UserViewModel> Users { get; set; }
        public void LoadUsers()
        {
            GroupLoading = Task.Run(async () => {
                var GroupsAndUsers = await RanksApi.IGetGroupGQL.SendQueryAsync(API.Client, new RanksApi.IGetGroupGQL.Variables { id = this.Group.id });
                List<User> users = GroupsAndUsers.Data.Group.users;

                Users = new ObservableCollection<UserViewModel>(
                    users.Select((user) => new UserViewModel(user, EditCommand))
                );
                GC.Collect(); // TODO: Что вот он собирает, ничего же нет!!!!!(Выяснить что собирает GC)
            });
        }
        public void UnloadUsers()
        {
            if (GroupLoading != null &&
                (
                    GroupLoading.Status == TaskStatus.RanToCompletion ||
                    GroupLoading.Status == TaskStatus.Running
                )
            )
            {
                GroupLoading.Dispose();
            }
            if (Users != null)
            {
                Users.Clear();
            }

        }
        #endregion
    }
}