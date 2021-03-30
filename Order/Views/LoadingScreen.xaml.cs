using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Order.Views
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Page
    {
        public LoadingScreen()
        {
            InitializeComponent();
            Task.Run(StartLoadingAnimation);
        }

        private async Task StartLoadingAnimation()
        {
            while (true)
            {

                for (int i = 0; i < 20; i++)
                    await ChangeImagePos(1);
                for (int i = 20; i > 0; i--)
                    await ChangeImagePos(-1);

                if (!this.IsVisible && this.IsInitialized) break;
            }
        }

        private async Task ChangeImagePos(double merginBottom)
        {
            Application.Current?.Dispatcher.Invoke(() =>
            {
                if (LogoImg != null)
                {
                    LogoImg.Margin = new Thickness(0, 0, 0, LogoImg.Margin.Bottom + merginBottom);
                }
            });
            await Task.Delay(25);
        }
    }
}
