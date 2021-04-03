using System.Windows;

namespace Order.WPF.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new ViewModels.MainViewModel();
            InitializeComponent();
        }

    }
}