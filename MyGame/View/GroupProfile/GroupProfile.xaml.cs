using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddGroupDialogue.xaml
    /// </summary>

    public partial class AddGroups
    {
        Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
        Group group = new Group();
        bool isImg = false;
        string loadedImg = "";
        //Заглушки
        string[] placeholders = new string[]{"Название","Описание"};
        public AddGroups(Group group = null)
        {

            InitializeComponent();
            if(group != null)
            {
                this.group = group;
                nameBox.Text = group.group;
                aboutBox.Text = group.about;
                GroupPic.Source = Db.BlobToPic(group.pic_blob);
            }
            else
            {
                this.group = new Group();
            }
        }


        private void AddUpdateGroup(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("диалог - " + dialog.FileName);

            group.group = nameBox.Text;            
            group.about = aboutBox.Text;

            if (isImg)
                Db.AddGroup(nameBox.Text, loadedImg, aboutBox.Text);
            else
                if (nameBox.Text != "" && nameBox.Text.Length < 6)
                Db.AddGroup(nameBox.Text, "", aboutBox.Text);
            //Thread thread = new Thread(addElement);
            //thread.Start();            
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
                loadedImg =dialog.SafeFileName;
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

        private void addElement()
        {
            this.Dispatcher.Invoke(()=>
            {
                
                
            });
            
        }
    }
}
