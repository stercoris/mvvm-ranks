using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ranks
{
    public class Group
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
        /// Пикча(blob)
        /// </summary>
        public byte[] pic_blob = Db.PicToBlob(new Bitmap("pack://application:,,,/img/no_image.jpg"), ImageFormat.Jpeg);

        /// <summary>
        /// Пикча(imagesource)
        /// </summary>
        public ImageSource picture;



    }

}
