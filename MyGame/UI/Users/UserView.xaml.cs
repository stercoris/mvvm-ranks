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
        public delegate void UserChoiceHandler(User user);
        public event UserChoiceHandler UserChoice;

        private User user;
        public UserView(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Uid = user.id.ToString();
            information.Text =  $"Имя : {user.name} \n" +
                        $"Фамилия : {user.sec_name} \n" +
                        $"Группа : {Db.GroupById(user.user_group)} \n" +
                        $"Ранг : {user.rank} \n" +
                        $"Описание : {user.about} \n";
            picture.Source = User.Base64ToBitmap(user.pic);
        }
        private void pic_MouseEnter(object sender, MouseEventArgs e)
        {
            CoolAnimation.start(picture, information, HeightProperty);
        }
        private void pic_MouseLeave(object sender, MouseEventArgs e)
        {
            CoolAnimation.end(picture, information, HeightProperty);
        }

        private void container_Click(object sender, RoutedEventArgs e)
        {
            UserChoice(this.user);
        }
    }
}
