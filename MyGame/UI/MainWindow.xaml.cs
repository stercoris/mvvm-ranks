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

namespace Ranks
{
    
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button layoutBtn = null;
        public MainWindow()
        {
            InitializeComponent();
            Db.OpenConnect("users.db");
            layoutBtn = (Button)FindName("def");
            GotoPage(Layouts.Ranks);
        }

        //Событие срабатывает при нажатии на кнопки слева
        private void PageChange(object sender, RoutedEventArgs e)
        {
            GotoPage((Layouts)Convert.ToInt32((sender as Button).Uid));
        }

        //Меняет цвет выбранной ячейки
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

        void GotoPage(Layouts page)
        {
            Change_Color(Convert.ToInt32(page));
            GridMain.Children.Clear();
            Frame next_frame;
            switch (page)
            {
                case Layouts.Users:
                    next_frame = new Users();
                    break;
                case Layouts.Profile:
                    next_frame = new Profile();
                    break;
                case Layouts.Ranks:
                    next_frame = new RankList();
                    break;
                case Layouts.Groups:
                    next_frame = new Groups();
                    break;
                default:
                    return;
            }
            next_frame.PageChanging += GotoPage;
            next_frame.UserChanging += GotoUser;
            next_frame.GroupUsersChanging += GotoGroupUsers;
            GridMain.Children.Add(next_frame);
        }

        void GotoUser(int userid)
        {
            Profile user = new Profile(Db.GetUser(userid));
            Change_Color(Convert.ToInt32(Layouts.Profile));
            GridMain.Children.Clear();
            GridMain.Children.Add(user);
        }
        void GotoGroupUsers(int groupid)
        {
            Users user = new Users(groupid);
            Change_Color(Convert.ToInt32(Layouts.Profile));
            GridMain.Children.Clear();
            GridMain.Children.Add(user);
        }
    }

    public enum Layouts
    {
        Users = 1,
        Profile = 2,
        Ranks = 3,
        Groups = 4,
        Games = 5,
    }
}
