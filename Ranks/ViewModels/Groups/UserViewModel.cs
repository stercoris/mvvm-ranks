using Ranks.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Ranks.ViewModels
{
    class UserViewModel : ReactiveObject
    {
        [Reactive] public User User { get; set; }
        [Reactive] public GroupsViewModel groupsvm { get; set; }
        public UserViewModel(GroupsViewModel groupsvm, User user)
        {
            this.User = user;
            this.groupsvm = groupsvm;
        }
    }
}
