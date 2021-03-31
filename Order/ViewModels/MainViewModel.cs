using Order.Views;
using Order.Views.Pages;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Serilog;

namespace Order.ViewModels
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
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            Log.Information("Logger was configurated");
            Log.Information("Start loading");
            PageContainer = new PageContainer();
            await Task.Delay(2000); //TODO: Для красоты, Убрать на релизе
            AppState = PageContainer;
        }
    }
}
