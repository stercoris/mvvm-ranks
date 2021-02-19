using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ranks.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ranks.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        #region Pages And Buttons
        private Page GroupList;
        private Page GroupProfile;
        private Page Users;
        private Page UserProfile;
        private Page RankList;
        private Page _selected_page;
        public Page SelectedPage
        {
            get => _selected_page;
            set => Set(ref _selected_page, value);
        }

        public ICommand bNavGroupListClick
        { get => new RelayCommand(() => SelectedPage = GroupList); }
        public ICommand bNavGroupProfileClick
        { get => new RelayCommand(() => SelectedPage = GroupProfile); }
        public ICommand bNavUsersClick
        { get => new RelayCommand(() => SelectedPage = Users); }
        public ICommand bNavUserProfileClick
        { get => new RelayCommand(() => SelectedPage = UserProfile); }
        public ICommand bNavRankListClick
        { get => new RelayCommand(() => SelectedPage = RankList); }

        #endregion

        private GroupsViewModel _group_view_model;
        public GroupsViewModel GroupViewModel
        {
            get => _group_view_model;
            set => Set(ref _group_view_model, value);
        }

        public MainViewModel()
        {
            GroupList = new View.Groups();
            GroupProfile = new View.GroupProfile();
            Users = new View.Users() {DataContext = this};
            UserProfile = new View.UserProfile();
            RankList = new View.RankList();

            GroupViewModel = new GroupsViewModel();
            SelectedPage = Users;
        }
    }
}
