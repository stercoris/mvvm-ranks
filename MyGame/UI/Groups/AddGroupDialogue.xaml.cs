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
    
    public partial class AddGroupDialogue : Window
    {
        bool isImg = false;
        string loadedImg = "";
        public AddGroupDialogue()
        {
            InitializeComponent();
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //if(isImg) 
            //    Db.AddGroup(nameBox.Text, loadedImg);
            //else
            //    if (nameBox.Text != "" && nameBox.Text.Length < 6) 
            //        Db.AddGroup(nameBox.Text, "");
            //this.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
