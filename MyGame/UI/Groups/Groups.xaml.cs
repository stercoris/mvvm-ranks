using MaterialDesignThemes.Wpf;
using Ranks;
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
    /// <summary>
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : UserControl
    {
        public Groups()
        {
            InitializeComponent();
            DrawGroups();

        }
        void DrawGroups()
        {
            
            List<Group> groups = Db.GetGroups();
            StackPanel GroupRow = new StackPanel()
            {
                Margin = new Thickness(0),
                Orientation = Orientation.Horizontal,
            };
            var converter = new BrushConverter();
            foreach (var group in groups)
            {
                if (GroupRow.Children.Count > 3)
                {
                    GroupListView.Children.Add(GroupRow);
                    GroupRow = new StackPanel()
                    {
                        Margin = new Thickness(0),
                        Orientation = Orientation.Horizontal,
                    };
                }
                GroupView view = new GroupView(group);
                //view.GroupChoice += click_ChangeUser;
                GroupRow.Children.Add(view);
               
            }
            if (!GroupListView.Children.Contains(GroupRow))
            {
                GroupListView.Children.Add(GroupRow);
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddGroupDialogue addGroups = new AddGroupDialogue();
            //this.IsEnabled = false;
            addGroups.Top = 400;
            addGroups.Show();   
            //GroupListView.Children.Clear();
            //GroupListView.Children.Add(addGroups);

        }
    }
}
