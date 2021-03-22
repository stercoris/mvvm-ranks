using System.Windows.Media;
using RanksClient.Services;

namespace RanksClient.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public Rank Rank { get; set; }
        public int GroupId { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public string About { get; set; }

        public string _picture;
        public string Picture
        {
            get => _picture; 
            set => _picture = ImageConverter.toBase64(ImageConverter.toImage(value));
        }

        public ImageSource hqImage { get => ImageConverter.toImage(Picture); }
        public ImageSource lqImage { get => ImageConverter.toImage(Picture); }

    }
}
