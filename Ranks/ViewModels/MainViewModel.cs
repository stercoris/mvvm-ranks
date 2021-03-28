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
            await DataAccess.RanksStorage.LoadRanks();
            await Task.Delay(5000);
            PageContainer = new PageContainer();
            AppState = PageContainer;
        }
    }
}
