using Order.Views;
using Order.Views.Pages;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Serilog;
using System.Linq;

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

            // Это говно????
            (new Thread(async () =>
            {
                while(Application.Current != null)
                {
                    await DataAccess.DBProvider.DBContext.SaveChangesAsync();
                    Thread.Sleep(500);
                }
            })).Start();

            PageContainer = new PageContainer();
            await Task.Delay(2000); //TODO: Для красоты, Убрать на релизе
            AppState = PageContainer;
        }
    }
}
