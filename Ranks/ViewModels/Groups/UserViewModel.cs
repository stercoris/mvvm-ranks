using Ranks.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Ranks.ViewModels
{
    class UserViewModel : ReactiveObject
    {
        [Reactive] public User User { get; set; }
        [Reactive] public GroupsViewModel groupsvm { get; set; }
        public ICommand Select
        { get => ReactiveCommand.Create(() => groupsvm.CurrentlySelectedObject = this); }
        public UserViewModel(GroupsViewModel groupsvm, User user)
        {
            this.User = user;
            this.groupsvm = groupsvm;
        }
    }
}
