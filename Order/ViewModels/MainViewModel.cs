using Order.DataAccess;
using Order.Views.Pages;
using Order.WPF.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

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

            // LOGGING
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            Log.Information("Logger was configurated");
            Log.Information("Start loading");
            // LOGGING

            // AUTOSAVING
            DispatcherTimer autoSaveTimer = new()
            {
                Interval = TimeSpan.FromSeconds(1),
            };
            autoSaveTimer.Tick += (sender, args) =>
            {
                try { DBProvider.DBContext.SaveChanges(); }
                catch { }
            };
            autoSaveTimer.Start();
            // AUTOSAVING

            // STARTUP
            PageContainer = new PageContainer();
            //await Task.Delay(1000); //TODO: Для красоты, Убрать на релизе
            AppState = PageContainer;
            // STARTUP

        }
    }
}
