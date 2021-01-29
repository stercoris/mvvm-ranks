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
    public class User 
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public int id;
        /// <summary>
        /// Имя
        /// </summary>
        public string name = "Имя";
        /// <summary>
        /// Фамилия
        /// </summary>
        public string sec_name = "Фамилия";
        /// <summary>
        /// Группа
        /// </summary>
        public int user_group = 1;
        /// <summary>
        /// Ранг
        /// </summary>
        public int rank = 1;
        /// <summary>
        /// Админ
        /// </summary>
        public bool is_admin = false;
        /// <summary>
        /// Пароль
        /// </summary>
        public string pass = "";
        /// <summary>
        /// Пикча(base64)
        /// </summary>
        public string pic = picToBase64(new BitmapImage(new Uri("pack://application:,,,/img/no_image.jpg")));
        /// <summary>
        /// Описание
        /// </summary>
        public string about = "Кратко";
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
            return(Convert.ToBase64String(byteImage));
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
            return(bitmapImage);
        }
        public override string ToString()
        {
            string u = $"Имя {name},Фамилия {sec_name},Ранк {rank},Является адменом {is_admin},Пароль {pass},Abo {about},\nPic {pic}";
            return u;
        }
    }
    
}
