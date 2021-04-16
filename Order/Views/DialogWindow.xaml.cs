using System.Windows;

namespace Order.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        private void Button_Confirm(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
