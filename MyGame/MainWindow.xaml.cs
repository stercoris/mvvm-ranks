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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button layoutBtn = null;
        public MainWindow()
        {
            InitializeComponent();
            Db.OpenConnect("users.db");
            User user = new User();
            layoutBtn = (Button)FindName("def");
            PageChange(layoutBtn, null);
        }

        //Событие срабатывает при нажатии на кнопки слева
        private void PageChange(object sender, RoutedEventArgs e)
        {
            ChangeLayout(Convert.ToInt32((sender as Button).Uid));
        }
        //Событие срабатывает при нажатии на иконку пользователя и приводит к страничке редактирования
        private void GotoDef(object sender, EventArgs e)
        {
            ChangeLayout(Layouts.Users);
        }
        //Событие срабатывает при добавлении или удалении пользователя
        private void GotoUser(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as UserControl).Uid);
            ChangeLayout(Layouts.Profile, id);
        }
        //Меняет слой на нужный
        private void ChangeLayout(int uid, int id = -1)
        {
            Change_Color(uid);
            GridMain.Children.Clear();
            switch (uid)
            {
                case Layouts.Users:
                    Users usc = new Users();
                    usc.ChangeUser += GotoUser;
                    GridMain.Children.Add(usc);
                    break;
                case Layouts.Profile:
                    User user = Db.GetUser(id);
                    AddUser addUser = new AddUser(user);
                    addUser.GotoDef += GotoDef;
                    GridMain.Children.Add(addUser);
                    break;
                case Layouts.Ranks:
                    RankList rank = new RankList();
                    GridMain.Children.Add(rank);
                    break;
                case Layouts.Groups:
                    break;
                default:
                    break;
            }
        }


        //Меняет цввет выбранной ячейки
        private void Change_Color(int uid)
        {
            var converter = new BrushConverter();
            layoutBtn.Background = (Brush)converter.ConvertFromString("#173763");
            layoutBtn.Foreground = (Brush)converter.ConvertFromString("#135BAB");
            layoutBtn = (Button)GetByUid(ListViewMenu, uid.ToString());
            layoutBtn.Background = (Brush)converter.ConvertFromString("#135BAB");
            layoutBtn.Foreground = (Brush)converter.ConvertFromString("#173763");
            int pagenum = Convert.ToInt32(layoutBtn.Uid);
        }

        private void App_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void App_RUP(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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
    }

    static class Layouts
    {
        public const int Users = 1;
        public const int Profile = 2;
        public const int Ranks = 3;
        public const int Groups = 4;
    }
}
