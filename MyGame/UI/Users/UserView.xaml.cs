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
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public event EventHandler<User> UserChoice;
        private User user;
        public UserView(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Uid = user.id.ToString();
            inf.Text =  $"Имя : {user.name} \n" +
                        $"Фамилия : {user.sec_name} \n" +
                        $"Группа : {Db.GroupById(user.user_group)} \n" +
                        $"Ранг : {user.rank} \n" +
                        $"Описание : {user.about} \n";
            pic.Source = User.Base64ToBitmap(user.pic);
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
            UserChoice(this, this.user);
        }
    }
}
