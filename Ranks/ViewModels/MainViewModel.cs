using Ranks.Views;
using Ranks.Views.Pages;
using RanksClient;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ranks.ViewModels
{
    internal class MainViewModel : ReactiveObject
    {
        [Reactive] public Page AppState { get; set; }

        #region Pages
        [Reactive] public Page PageContainer { get; set; }
        [Reactive] public Page LoadingScreen { get; set; }
        #endregion
        public MainViewModel()
        {
            LoadingScreen = new LoadingScreen();
            AppState = LoadingScreen;
            Loading();
        }

        private async Task Loading()
        {
            await Task.Run(DataAccess.RanksStorage.LoadRanks);
            await Task.Run(async () =>
            {
                var groups = await DataAccess.GroupsStorage.LoadGroups();
                if (groups.Count > 0)
                {
                    //await DataAccess.UsersStorage.LoadUsers(groups[0].id);
                    //DataAccess.UsersStorage.LoadUsers(groups[1].id);    //TODO: Для тестинга, Убрать на релизе
                    //DataAccess.UsersStorage.LoadUsers(groups[2].id);    //TODO: Для тестинга, Убрать на релизе
                }
            });
            PageContainer = new PageContainer();
            await Task.Delay(2000); //TODO: Для красоты, Убрать на релизе
            AppState = PageContainer;
        }
    }
}
