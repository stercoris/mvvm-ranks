using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
            double startPoint = ActualHeight;
            double finishPoint = 150;
            RotateTransform rotateTransform = new(180);
            if (startPoint == finishPoint)
            {
                finishPoint = 60;
                rotateTransform = new(0);
            }
            DoubleAnimation rankSizeAnimation = new();
            rankSizeAnimation.From = startPoint;
            rankSizeAnimation.To = finishPoint;
            rankSizeAnimation.Duration = TimeSpan.FromSeconds(0.3);
            BeginAnimation(Button.HeightProperty, rankSizeAnimation);

            (sender as Button).RenderTransform = rotateTransform;
        }
    }
}
