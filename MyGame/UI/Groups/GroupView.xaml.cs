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
        public delegate void GroupButtonHandler (Group group);
        public event GroupButtonHandler GroupButtonPressed;
        public Group group;
        public GroupView(Group group)
        {
            InitializeComponent();
            this.group = group;
            //this.Uid = group.id.ToString();
            information.Text = $"Группа: {group.group} \n Описание: {group.about}";
            if(group.pic != "")
                picture.Source = Db.Base64ToBitmap(group.pic);
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
            GroupButtonPressed(this.group);
        }
    }
}
