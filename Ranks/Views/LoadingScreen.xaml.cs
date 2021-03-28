using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ranks.Views
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
            Application.Current.Dispatcher.Invoke(() =>
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
