using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Order.WPF.ViewModels;

namespace Order.WPF.Views.Pages.Ranks
{
    /// <summary>
    /// Логика взаимодействия для RankView.xaml
    /// </summary>
    public partial class RankView : UserControl
    {

        public RankView()
        {
            InitializeComponent();
        }
        private void ExpandRankClick(object sender, RoutedEventArgs e)
        {
            


        }
        
       Style OrderTextBox = Application.Current.FindResource("OrderTextBox") as Style;
       Style ChangeableOrderTextBox = Application.Current.FindResource("ChangeableOrderTextBox") as Style;
        private void groupName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!groupName.IsReadOnly)
            {
                groupName.IsReadOnly = true;
                groupName.Style = OrderTextBox;
                ImageUpload.Visibility = Visibility.Hidden;
                DeleteRank.Visibility = Visibility.Hidden;
            }
            else
            {
                ImageUpload.Visibility = Visibility.Visible;
                DeleteRank.Visibility = Visibility.Visible;
                groupName.IsReadOnly = false;
                groupName.Style = ChangeableOrderTextBox;
            }
        }

        private void groupName_LostFocus(object sender, RoutedEventArgs e)
        {
            groupName.IsReadOnly = true;
            ImageUpload.Visibility = Visibility.Hidden;
            groupName.Style = OrderTextBox;
            DeleteRank.Visibility = Visibility.Hidden;
        }
    }
}
