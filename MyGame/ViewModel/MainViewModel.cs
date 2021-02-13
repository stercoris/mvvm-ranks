using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
        #region Pages
        private Page GroupList;
        private Page GroupProfile;
        private Page Users;
        private Page UserProfile;
        private Page RankList;
        private Page _selected_page;
        public Page SelectedPage
        {
            get { return _selected_page; }
            set { if (value != _selected_page) Set(ref _selected_page, value); }
        }

        public ICommand bNavGroupListClick 
        { get { return new RelayCommand(() => SelectedPage = GroupList);} }
        public ICommand bNavGroupProfileClick
        { get { return new RelayCommand(() => SelectedPage = GroupProfile); } }
        public ICommand bNavUsersClick
        { get { return new RelayCommand(() => SelectedPage = Users); } }
        public ICommand bNavUserProfileClick
        { get { return new RelayCommand(() => SelectedPage = UserProfile); } }
        public ICommand bNavRankListClick
        { get { return new RelayCommand(() => SelectedPage = RankList); } }

        #endregion


        public MainViewModel()
        {
            GroupList = new View.Groups();
            GroupProfile = new View.GroupProfile();
            Users = new View.Users();
            UserProfile = new View.UserProfile();
            RankList = new View.RankList();

            this.SelectedPage = Users;
        }
    }
}
