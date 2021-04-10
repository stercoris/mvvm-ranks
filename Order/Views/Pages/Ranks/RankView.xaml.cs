using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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
        private void ExpandRankClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if(groupName.IsEnabled == false)
            {
                groupName.IsEnabled = true;
                materialIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Done;
            }
            else
            {
                groupName.IsEnabled = false; 
                materialIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Create;
            }

            double startPoint = ActualHeight;
            double finishPoint = 150;
            if (startPoint == finishPoint)
            {
                finishPoint = 80;
            }
            DoubleAnimation rankSizeAnimation = new();
            rankSizeAnimation.From = startPoint;
            rankSizeAnimation.To = finishPoint;
            rankSizeAnimation.Duration = TimeSpan.FromSeconds(0.3);
            BeginAnimation(Button.HeightProperty, rankSizeAnimation);
        }
    }
}
