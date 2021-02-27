using Ranks.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Ranks.ViewModels
{
    class GroupViewModel : ReactiveObject
    {
        [Reactive] public Group Group { get; set; }
        [Reactive] public GroupsViewModel groupsvm { get; set; }
        public ICommand ShowUsersCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public GroupViewModel(GroupsViewModel groupsvm, Group group)
        {
            this.Group = group;
            this.groupsvm = groupsvm;
            // Требуется вынести в родительский класс, зачем создавать так много экземпляров команды?????????????
            ShowUsersCommand = ReactiveCommand.Create(() => groupsvm.SelectedGroup = this);
            EditCommand = ReactiveCommand.Create(() => groupsvm.CurrentlyEditableObject = this);
        }
        public void Select()
        {
            groupsvm.SelectedGroup = this;
        }
    }
}
