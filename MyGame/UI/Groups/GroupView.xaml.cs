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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ranks
{
    /// <summary>
    /// Логика взаимодействия для GroupView.xaml
    /// </summary>
    public partial class GroupView : UserControl
    {
        public event EventHandler<Group> GroupChoice;
        public Group group;
        public GroupView(Group group)
        {
            InitializeComponent();
            this.group = group;
            //this.Uid = group.id.ToString();
            inf.Text = $"Группа: {group.group} \n Описание: {group.about}";
            if(group.pic != null)
                pic.Source = group.picture;
        }
        private void pic_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = pic.ActualHeight;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.1));
            pic.Stretch = Stretch.Uniform;
            pic.BeginAnimation(HeightProperty, myDoubleAnimation);
            inf.Visibility = Visibility.Visible;
            inf.VerticalAlignment = VerticalAlignment.Top;
        }
        private void pic_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = pic.Height;
            myDoubleAnimation.To = 110;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.1));
            pic.Stretch = Stretch.Fill;
            pic.BeginAnimation(HeightProperty, myDoubleAnimation);
            inf.Visibility = Visibility.Hidden;
            inf.VerticalAlignment = VerticalAlignment.Center;
        }

        private void container_Click(object sender, RoutedEventArgs e)
        {
            GroupChoice(this, this.group);
        }
    }
}
