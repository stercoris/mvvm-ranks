using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        [Browsable(true)] [Category("Action")]
        [Description("On user click")]
        public event EventHandler ChangeUser;
        public Users()
        {

            InitializeComponent();
            List<string> grouplist = new List<string> { };
            foreach (var groupname in Db.GetGroups())
                    grouplist.Add(groupname);
            groupList.ItemsSource = grouplist;
            groupList.SelectedIndex = 0;
            DrawUsers("aa");
        }
        void DrawUsers(string Group)
        {
            StackPanel userRow = new StackPanel()
            {
                Margin = new Thickness(0),
                Orientation = Orientation.Horizontal,
            }; 
            Dictionary<int, User> users = Db.GetAllUsers();
            foreach(var user in users)
            {
                if(userRow.Children.Count > 3)
                {
                    userList.Children.Add(userRow);
                    userRow = new StackPanel()
                    {
                        Margin = new Thickness(0),
                        Orientation = Orientation.Horizontal,
                    };
                }
                UserView view = new UserView(user.Value);
                view.UserChoice += click_ChangeUser;
                userRow.Children.Add(view);
            }
            if(!userList.Children.Contains(userRow))
            {
                userList.Children.Add(userRow);
            }
        }
        private void userPic_MouseEnter(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            Image userPic = (Image)GetByUid(bt, "userPic");
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = userPic.ActualHeight;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.1));
            userPic.BeginAnimation(HeightProperty, myDoubleAnimation);
            Grid userInf = (Grid)GetByUid(bt, "userInf");
            userInf.Visibility = Visibility.Visible;
            userInf.VerticalAlignment = VerticalAlignment.Top;
        }
        private void userPic_MouseLeave(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            Image userPic = (Image)GetByUid(bt, "userPic");
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = userPic.Height;
            myDoubleAnimation.To = 160;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.1));
            userPic.BeginAnimation(HeightProperty, myDoubleAnimation);
            Grid userInf = (Grid)GetByUid(bt, "userInf");
            userInf.Visibility = Visibility.Hidden;
            userInf.VerticalAlignment = VerticalAlignment.Center;
        }
        public static UIElement GetByUid(DependencyObject rootElement, string uid)
        {
            foreach (UIElement element in LogicalTreeHelper.GetChildren(rootElement).OfType<UIElement>())
            {
                if (element.Uid == uid)
                    return element;
                UIElement resultChildren = GetByUid(element, uid);
                if (resultChildren != null)
                    return resultChildren;
            }
            return null;
        }
        protected void click_ChangeUser(object sender, User user)
        {
            
            if (this.ChangeUser != null)
                this.ChangeUser(sender, user);
        }
    }
}
