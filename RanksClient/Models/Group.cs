using System.Collections.Generic;
using RanksClient.Services;
using System.Windows.Media;

namespace RanksClient.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public List<User> Users { get; set; }
        public string Picture { get; set; }
        public ImageSource hqImage { get => ImageConverter.toImage(Picture, 960, 640); }
        public ImageSource lqImage { get => ImageConverter.toImage(Picture); }
        private string avrgRank { get; set; }
        public string AvrgRank { 
            get => "Средний ранг:\n" + avrgRank;
            set => avrgRank=value; 
        }
    }
}
