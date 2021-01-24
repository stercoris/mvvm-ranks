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

namespace Ranks
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Frame
    {
        bool isGroupSelected = true;
        public Users(int selectedGroup = -1)
        {
            InitializeComponent();
            SetupGroupList();
            if(selectedGroup != -1)
                DrawUsers(selectedGroup);
            else
            {
                isGroupSelected = false;
                DrawUsers();
            }
        }   
        void DrawUsers(int group = -1)
        {
            StackPanel userRow = new StackPanel()
            {
                Margin = new Thickness(0),
                Orientation = Orientation.Horizontal,
            };

            List<User> users;

            if (isGroupSelected)
                users = Db.GetAllUsers().FindAll(user => user.user_group != group);
            else
                users = Db.GetAllUsers();

            foreach (var user in users)
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
                UserView view = new UserView(user);
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
        private void userPic_MouseLeave(object sender, MouseEventArgs e)//ана может запустить ну тип ты можеш посмотреть анимацию какую ана запускает)
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

        /// <summary>
        /// Устанавливает значения в список "Список групп"
        /// </summary>
        private void SetupGroupList()
        {
            groupList.ItemsSource = Db.GetGroups().Select(group => group.group);
            groupList.SelectedIndex = 0;
        }

        protected void click_ChangeUser(User user)
        {
            GotoUser(user.id);
        }
    }
}
