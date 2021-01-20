using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        [Browsable(true)] [Category("Action")]
        [Description("On user delete")]
        public event EventHandler GotoDef;
        BitmapImage no_image = new BitmapImage(new Uri("pack://application:,,,/img/no_image.jpg"));

        //Заглушки
        string[] placeholders = new string[]
        { "Фамилия","Имя","Кратко","Ранг"};

        //Исходные данные пользователя(null если нет оного)
        private User sourse_user;
        
        //Измененные данные пользователя
        private User user;


        public AddUser(User user)
        {
            this.user = user;
            this.sourse_user = user;
            InitializeComponent();
            groupList.ItemsSource = Db.GetGroups();
            groupList.SelectedIndex = 0;
            userPic.Source = no_image;
            if (user == null)
                this.user = new User();
            ChangeUi();

        }
        /// <summary>
        /// Вызывается в случае принятия пользователя на редактирование
        /// </summary>
        private void ChangeUi()
        {
            try
            {
                userPic.Source = User.Base64ToBitmap(user.pic);
            }
            catch
            {
                userPic.Source =
                 new BitmapImage(new Uri("pack://application:,,,/img/no_image.jpg"));
            }
            nameBox.Text = user.name;
            secNameBox.Text = user.sec_name;
            groupList.SelectedItem = user.user_group;
            rankBox.Text = user.rank.ToString();
            addUser.Content = "Изменить пользователя";
            aboutBox.Text = user.about;
            deleteUser.Visibility = Visibility.Visible;
            rankName.Visibility = Visibility.Visible;
            rankName.Text = Db.GetRank(user.rank);
        }
        public void RemoveText(object sender, EventArgs e)
        {
            TextBox myTxtbx = sender as TextBox;
            if (placeholders.Contains(myTxtbx.Text))
            {
                myTxtbx.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            TextBox myTxtbx = sender as TextBox;
            if (string.IsNullOrWhiteSpace(myTxtbx.Text))
                switch(myTxtbx.Name) 
                {
                    case ("nameBox"):
                        myTxtbx.Text = "Имя";
                        break;
                    case ("secNameBox"):
                        myTxtbx.Text = "Фамилия";
                        break;
                    case ("rankBox"):
                        myTxtbx.Text = "Ранг";
                        break;
                    case ("aboutBox"):
                        myTxtbx.Text = "Кратко";
                        break;
                }
        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = 
                "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if ((bool)dialog.ShowDialog()){
                user.pic = User.picToBase64(new BitmapImage(new Uri(dialog.FileName)));
                userPic.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }
        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            if (sourse_user == null)
                Db.AddUser(user);
            else if (sourse_user != user)
                Db.UpdateUser(user);

        }
        
        /// <summary>
        /// Нажатие на кнопку удалить пользователя
        /// </summary>
        protected void click_DeleteUser(object sender, RoutedEventArgs e)
        {
            Db.DeleteUser(user.id);
            (sender as Button).Uid = user.id.ToString();
            GotoDef?.Invoke(sender, e);//Если GotoDef не равно null , то вызывает (делегат?) событие.
        }
        /// <summary>
        /// Нажатие на стрелку вверх
        /// </summary>
        private void AddOne(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(rankBox.Text, out int rank))
                user.rank++;
            else
                MessageBox.Show("Вы не указали ранг");
        }
        /// <summary>
        /// Нажатие на стрелку вниз
        /// </summary>
        private void RemoveFromRank(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(rankBox.Text, out int rank))
                user.rank--;
            else
                MessageBox.Show("Вы не указали ранг");
        }
        /// <summary>
        /// При изменении поля "ранг"
        /// </summary>
        private void rankChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse((sender as TextBox).Text,out int rankId))
                rankName.Text = Db.GetRank(rankId);
        }
    }
}
