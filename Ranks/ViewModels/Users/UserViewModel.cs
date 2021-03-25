﻿using RanksClient.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Ranks.ViewModels
{
    class UserViewModel : ReactiveObject
    {
        [Reactive] public User User { get; set; }
        [Reactive] public GroupsAndUsersViewModel groupsvm { get; set; }
        public ICommand Select
        { get => ReactiveCommand.Create(() => groupsvm.CurrentlyEditableObject = this); }
        public UserViewModel(GroupsAndUsersViewModel groupsvm, User user)
        {
            this.User = user;
            this.groupsvm = groupsvm;
        }
    }
}