using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Image = System.Windows.Controls.Image;

namespace Ranks
{
    static class CoolAnimation
    {
        public static void start(Image pic, TextBlock inf, DependencyProperty height)
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = pic.ActualHeight;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.1));
            pic.Stretch = Stretch.Uniform;
            pic.BeginAnimation(height, myDoubleAnimation);
            inf.Visibility = Visibility.Visible;
            inf.VerticalAlignment = VerticalAlignment.Top;
        }
        public static void end(Image pic, TextBlock inf, DependencyProperty height)
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = pic.Height;
            myDoubleAnimation.To = 110;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.1));
            pic.Stretch = Stretch.Fill;
            pic.BeginAnimation(height, myDoubleAnimation);
            inf.Visibility = Visibility.Hidden;
            inf.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
