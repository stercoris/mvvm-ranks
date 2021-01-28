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
        /// Айди
        /// </summary>
        public int id;

        /// <summary>
        /// описание
        /// </summary>
        public string about;

        /// <summary>
        /// Пикча(base64)
        /// </summary>
        public string pic = Db.picToBase64(new BitmapImage(new Uri("pack://application:,,,/img/no_image.jpg")));

       
    }

}
