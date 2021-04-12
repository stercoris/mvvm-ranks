using Order.WPF.Views.Pages.MainPage;
using Order.WPF.Views.Pages.Ranks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using System.Windows.Controls;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    class PageController : ReactiveObject
    {

        #region Pages And NavBar
        private Page GroupsAndUsers;
        private Page RankList;

        [Reactive] public Page SelectedPage { get; set; }

        public ICommand bNavGroupsAndUsersClick
        { get => ReactiveCommand.Create(() => SelectedPage = GroupsAndUsers); }
        public ICommand bNavRankListClick
        { get => ReactiveCommand.Create(() => SelectedPage = new RankList() { DataContext = new RanksViewModel() }); }

        #endregion

        #region ChildrenViewModels
        [Reactive] public MainPageViewModel GroupsViewModel { get; set; }
        [Reactive] public RanksViewModel RanksViewModel { get; set; }
        #endregion

        public PageController()
        {
            GroupsViewModel = new MainPageViewModel();
            RanksViewModel = new RanksViewModel();
            GroupsAndUsers = new MainPageView() { DataContext = this };
            SelectedPage = GroupsAndUsers;
            Log.Information($"{nameof(PageController)} was succ created");
        }
    }
}
