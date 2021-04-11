using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Order.WPF.Views.CustomForms
{
    /// <summary>
    /// Interaction logic for ImageUpload.xaml
    /// </summary>
    public partial class ImageUploadButton : UserControl, INotifyPropertyChanged
    {
        public ImageUploadButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        [Reactive] public string Picture { get; set; }

        public static readonly DependencyProperty PictureProperty =
           DependencyProperty.Register("Picture", typeof(string), typeof(ImageUploadButton),
               new FrameworkPropertyMetadata(null,
                   FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
            };
            if ((bool)dialog.ShowDialog())
            {
                BitmapSource image = (new BitmapImage(new Uri(dialog.FileName)));
                MemoryStream outStream = new();
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(image));
                enc.Save(outStream);
                Bitmap bitmap = new(outStream);
                Bitmap bm = new(bitmap);
                MemoryStream ms = new MemoryStream();
                bm.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                outStream.Close();
                ms.Close();
                this.Picture = System.Convert.ToBase64String(byteImage);
            }
        }
    }
}
