using RanksClient;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ranks.ViewModels
{
    internal class MainViewModel : ReactiveObject
    {
        #region Pages And NavBar
        private Page GroupsAndUsers;
        private Page RankList;

        [Reactive] public Page SelectedPage { get; set; }

        public ICommand bNavGroupsAndUsersClick
        { get => ReactiveCommand.Create(() => SelectedPage = GroupsAndUsers); }
        public ICommand bNavRankListClick
        { get => ReactiveCommand.Create(() => SelectedPage = RankList); }

        #endregion

        #region ChildrenViewModels
        [Reactive] public GroupsAndUsersViewModel GroupsViewModel { get; set; }
        [Reactive] public RanksViewModel RanksViewModel { get; set; }
        #endregion

        public API api { get; set; }

        public MainViewModel()
        {
            api = new API("http://localhost:8000/graphql");
            GroupsAndUsers = new View.GroupsAndUsers() { DataContext = this };
            RankList = new View.RankList() { DataContext = this };

            GroupsViewModel = new GroupsAndUsersViewModel(api);
            RanksViewModel = new RanksViewModel();
            SelectedPage = GroupsAndUsers;

        }
    }
}
