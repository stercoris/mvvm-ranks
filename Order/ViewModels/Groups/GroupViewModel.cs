using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Order.ViewModels
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
        [Reactive] public ObservableCollection<UserViewModel> Users { get; set; }
        public void LoadUsers()
        {
            Users = new ObservableCollection<UserViewModel>(
                DBProvider.DBContext.Students
                    .Where((student) => student.Group.Id == this.Group.Id)
                    .Select((user) => new UserViewModel(user, EditCommand))
            );
        }
        public void UnloadUsers()
        {
            Users.Clear();
        }
        #endregion
    }
}