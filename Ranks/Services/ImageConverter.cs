using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Ranks.Services
{
    static class ImageConverter
    {
        /// <summary>
        /// BitmapImage to Base64 string
        /// </summary>
        /// <param name="img">image</param>
        /// <returns></returns>
        public static string toBase64(BitmapImage img)
        {
            MemoryStream outStream = new MemoryStream();
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(img));
            enc.Save(outStream);
            Bitmap bitmap = new Bitmap(outStream);
            Bitmap bm = new Bitmap(bitmap);
            MemoryStream ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            return (Convert.ToBase64String(byteImage));
        }

        /// <summary>
        /// Base64 string to BitmapImage
        /// </summary>
        /// <param name="base64String">base 64 string</param>
        /// <returns></returns>
        public static BitmapImage toBitmapImage(string base64String)
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
    }
}
