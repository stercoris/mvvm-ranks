using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Order.WPF.ViewModels
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
    }
}