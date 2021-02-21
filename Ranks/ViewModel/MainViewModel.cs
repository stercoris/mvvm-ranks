using Ranks.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ranks.ViewModel
{
    internal class MainViewModel : ReactiveObject
    {
        #region Pages And Buttons
        private Page GroupList;
        private Page GroupProfile;
        private Page Users;
        private Page UserProfile;
        private Page RankList;

        [Reactive] public Page SelectedPage { get; set; }

        public ICommand bNavGroupListClick
        { get => ReactiveCommand.Create(() => SelectedPage = GroupList); }
        public ICommand bNavGroupProfileClick
        { get => ReactiveCommand.Create(() => SelectedPage = GroupProfile); }
        public ICommand bNavUsersClick
        { get => ReactiveCommand.Create(() => SelectedPage = Users); }
        public ICommand bNavUserProfileClick
        { get => ReactiveCommand.Create(() => SelectedPage = UserProfile); }
        public ICommand bNavRankListClick
        { get => ReactiveCommand.Create(() => SelectedPage = RankList); }

        #endregion

        #region ChildrenViewModels
        [Reactive]
        public GroupsViewModel GroupViewModel
        { get; set; }

        [Reactive]
        public RanksViewModel RanksViewModel
        { get; set; }
        #endregion


        public MainViewModel()
        {
            GroupList = new View.Groups() { DataContext = this };
            GroupProfile = new View.GroupProfile() { DataContext = this };
            Users = new View.Users() {DataContext = this};
            UserProfile = new View.UserProfile() { DataContext = this };
            RankList = new View.RankList() { DataContext = this };

            GroupViewModel = new GroupsViewModel();
            RanksViewModel = new RanksViewModel();
            SelectedPage = Users;

        }
    }
}
