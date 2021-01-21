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

namespace Ranks
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        [Browsable(true)] [Category("Action")]
        [Description("On user delete")]
        public event EventHandler GotoDef;

        // "Отсутствует изображение"
        readonly BitmapImage no_image = new BitmapImage(new Uri("pack://application:,,,/img/no_image.jpg"));

        //Заглушки
        string[] placeholders = new string[]
        {"Фамилия","Имя","Кратко","Ранг"};

        //Исходные данные пользователя(null если нет оного)
        private User user;
        
        //Измененные данные пользователя
        private User source_user;

        // Создание - изменение пользователя
        private bool isNewUser = false;

        /// <summary>
        /// Изменение пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        public AddUser(User user)
        {
            isNewUser = false;
            this.source_user = user;
            this.user = user;
            InitializeComponent();
            SetupGroupList();
            ChangeUi(this.user);
        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        public AddUser()
        {
            isNewUser = true;
            this.user = new User()
            {
                pic = User.picToBase64(no_image),
            };
            InitializeComponent();
            SetupGroupList();
            ChangeUi(this.user);
        }


        /// <summary>
        /// Вызывается в случае принятия пользователя на редактирование
        /// </summary>
        private void ChangeUi(User user)
        {
            try
            {
                userPic.Source = User.Base64ToBitmap(user.pic);
            }
            catch{}
            nameBox.Text = user.name;
            secNameBox.Text = user.sec_name;
            groupList.SelectedItem = user.user_group;
            rankBox.Text = user.rank.ToString();
            aboutBox.Text = user.about;
            if(isNewUser)
            {
                deleteUser.Visibility = Visibility.Hidden;
                addUser.Content = "Создать пользователя";
            }
            else
            {
                deleteUser.Visibility = Visibility.Visible;
                addUser.Content = "Изменить пользователя";
            }
            rankName.Visibility = Visibility.Visible;
            rankName.Text = Db.GetRank(user.rank);
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


        /// <summary>
        /// Загружает изображение из файловой системы
        /// </summary>
        private void AddImageClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = 
                "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if ((bool)dialog.ShowDialog()){
                this.user.pic = User.picToBase64(new BitmapImage(new Uri(dialog.FileName)));
                userPic.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        /// <summary>
        /// Добавляет пользователя в базу данных
        /// </summary>
        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            user.name = nameBox.Text;
            user.sec_name = secNameBox.Text;
            user.user_group = Db.GetGroupId(groupList.Text);
            user.rank = int.Parse(rankBox.Text);
            user.about = aboutBox.Text;
            if (isNewUser)
            {
                Db.AddUser(user);
                GotoDef?.Invoke(sender, e);
            }
            else
            {
                Db.UpdateUser(user);
                GotoDef?.Invoke(sender, e);
            }

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
                rankBox.Text = (rank + 1).ToString();
            else
                MessageBox.Show("Вы не указали ранг");
        }

        /// <summary>
        /// Нажатие на стрелку вниз
        /// </summary>
        private void RemoveFromRank(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(rankBox.Text, out int rank))
                rankBox.Text = (rank - 1).ToString();
            else
                MessageBox.Show("Вы не указали ранг");
        }

        /// <summary>
        /// При изменении поля "ранг"
        /// </summary>
        private void rankChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse((sender as TextBox).Text,out int rankId))
            {
                Console.WriteLine(rankId);
                int ranks_count = Db.GetRanks().Count;
                if (rankId >= 0 && rankId < ranks_count)
                    rankName.Text = Db.GetRank(rankId);
                else if (rankId < 0)
                    rankBox.Text = "0";
                else if(rankId >= ranks_count)
                    rankBox.Text = ranks_count.ToString();

            }

        }

        /// <summary>
        /// Устанавливает значения в список "Список групп"
        /// </summary>
        private void SetupGroupList()
        {
            groupList.ItemsSource = Db.GetGroups();
            groupList.SelectedIndex = 0;
        }

        /// <summary>
        /// Удаляет placeholder'ы 
        /// </summary>
        public void RemoveText(object sender, EventArgs e)
        {
            TextBox myTxtbx = sender as TextBox;
            if (placeholders.Contains(myTxtbx.Text))
            {
                myTxtbx.Text = "";
            }
        }
    }
}
