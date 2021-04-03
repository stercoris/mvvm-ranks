using Order.DataAccess;
using Order.Views.Pages;
using Order.WPF.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Order.WPF.ViewModels
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
            var students = DBProvider.DBContext.Students;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            Log.Information("Logger was configurated");
            Log.Information("Start loading");

            (new Thread(async () =>
            {
                while (Application.Current != null)
                {
                    await DBProvider.DBContext.SaveChangesAsync();
                    Thread.Sleep(500);
                }
            })).Start();

            PageContainer = new PageContainer();
            await Task.Delay(2000); //TODO: Для красоты, Убрать на релизе
            AppState = PageContainer;
        }
    }
}
