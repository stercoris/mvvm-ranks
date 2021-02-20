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


        #region ChildrenViewModels
        private GroupsViewModel _group_view_model;
        public GroupsViewModel GroupViewModel
        {
            get => _group_view_model;
            set => Set(ref _group_view_model, value);
        }

        private RanksViewModel _ranks_view_model;
        public RanksViewModel RanksViewModel
        {
            get => _ranks_view_model;
            set => Set(ref _ranks_view_model, value);
        }
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
