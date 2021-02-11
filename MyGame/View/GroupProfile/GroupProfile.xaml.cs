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
    /// Логика взаимодействия для AddGroupDialogue.xaml
    /// </summary>

    public partial class AddGroups
    {
        bool isImg = false;
        string loadedImg = "";
        //Заглушки
        string[] placeholders = new string[]{"Название","Описание"};
        public AddGroups(Group group = null)
        {
            InitializeComponent();
            if(group != null)
            {
                nameBox.Text = group.group;
                aboutBox.Text = group.about;
                GroupPic.Source = Db.Base64ToBitmap(group.pic);
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (isImg)
                Db.AddGroup(nameBox.Text, loadedImg, aboutBox.Text);
            else
                if (nameBox.Text != "" && nameBox.Text.Length < 6)
                    Db.AddGroup(nameBox.Text, "", aboutBox.Text);
            //go back
            ChangePage(Layouts.Groups);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //go back
            ChangePage(Layouts.Groups);

        }

        private void AddImageClick(object sender, RoutedEventArgs e)
        {
            isImg = true;
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter =
                "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if ((bool)dialog.ShowDialog())
            {
                loadedImg = Db.picToBase64(new BitmapImage(new Uri(dialog.FileName)));
                GroupPic.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            TextBox myTxtbx = sender as TextBox;
            if (placeholders.Contains(myTxtbx.Text))
            {
                myTxtbx.Text = "";
            }
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nameBox_DragEnter(object sender, DragEventArgs e)
        {
            
        }

    }
}
