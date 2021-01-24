using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Ranks
{
    public class Group : EventArgs
    {
        
        /// <summary>
        /// Группа
        /// </summary>
        public string group;
        /// <summary>
        /// Пикча(base64)
        /// </summary>
        public string pic = picToBase64(new BitmapImage(new Uri("pack://application:,,,/img/no_image.jpg")));

       
        /// <summary>
        /// Переводит пикчу в base64
        /// </summary>
        public static string picToBase64(BitmapImage img)
        {
            MemoryStream outStream = new MemoryStream();
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(img));
            enc.Save(outStream);
            Bitmap bitmap = new System.Drawing.Bitmap(outStream);
            Bitmap bm = new Bitmap(bitmap);
            MemoryStream ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            return (Convert.ToBase64String(byteImage));
        }
        public static BitmapImage Base64ToBitmap(string base64String)
        {
            byte[] imgBytes = Convert.FromBase64String(base64String);

            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream ms = new MemoryStream(imgBytes);
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ms;
            bitmapImage.EndInit();

            //Image object
            return (bitmapImage);
        }
        public string ToString()
        {
            string u = $"Группа {group},\nPic {pic}";
            return u;
        }
    }

}
