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


        #region Groups, Group selection and Group finder
        public Commands.SelectGroupCommand SelectGroupCommand { get; set; }
        private List<Group> _groups;
        public List<Group> Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }
        private Group _selected_group;
        public Group SelectedGroup
        {
            get => _selected_group;
            set => Set(ref _selected_group, value);
        }
        public void SelectGroup(Group group)
        { SelectedGroup = group;}

        private string _search_string;
        public string SearchString
        {
            get => _search_string;
            set 
            {
                Set(ref _search_string, value);
                if (String.IsNullOrWhiteSpace(_search_string))
                    FoundGroups = Groups;
                else
                {
                    FoundGroups = Groups.FindAll((group) =>
                    {
                        return (group.Name.Contains(_search_string));
                    });
                }
                RaisePropertyChanged(nameof(FoundGroups));
            }
        }
        private List<Group> _found_groups;
        public List<Group> FoundGroups
        {
            get => _found_groups;
            set => Set(ref _found_groups, value);
        }
        #endregion


        public MainViewModel()
        {
            GroupList = new View.Groups();
            GroupProfile = new View.GroupProfile();
            Users = new View.Users() {DataContext = this};
            UserProfile = new View.UserProfile();
            RankList = new View.RankList();
            Groups = DataBase.Groups.GetGroups();

            SelectGroupCommand = new Commands.SelectGroupCommand(this);
            FoundGroups = Groups;
            SelectedPage = Users;
        }
    }
}
