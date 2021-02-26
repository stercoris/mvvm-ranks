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
        public ICommand SelectCommand { get; set; }

        public GroupViewModel(GroupsViewModel groupsvm, Group group)
        {
            this.Group = group;
            this.groupsvm = groupsvm;
            SelectCommand = new Commands.SelectGroupCommand(this);
        }
        public void Select()
        { groupsvm.SelectGroup(this); }
    }
}
