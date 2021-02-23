using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
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
        public static string toBase64(ImageSource img)
        {
            MemoryStream outStream = new MemoryStream();
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create((BitmapSource)img));
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
        public static ImageSource toImage(string base64String, int width = 197, int height = 170)
        {
            BitmapImage bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.DecodePixelWidth = width;
            bitmapImage.DecodePixelHeight = height;
            bitmapImage.CacheOption = BitmapCacheOption.None;
            bitmapImage.StreamSource = new MemoryStream(Convert.FromBase64String(base64String));
            bitmapImage.EndInit();

            return (bitmapImage);

        }
    }
}
