using System.Windows;
using System.Windows.Controls;

namespace Order.Views.Pages
{
    /// <summary>
    /// Interaction logic for PageContainer.xaml
    /// </summary>
    public partial class PageContainer : Page
    {
        public PageContainer()
        {
            InitializeComponent();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            var Window = Application.Current.MainWindow;
            Window.WindowState = WindowState.Minimized;
        }
    }
}
