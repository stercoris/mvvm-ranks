using GalaSoft.MvvmLight;
using System.Windows.Media;

namespace Ranks.Model
{
    class User : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _sec_name;
        private int _groupid;
        private Rank _rank;
        private bool _is_admin;
        private string _password;
        private ImageSource _image;
        private string _about;

        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string SecondName
        {
            get => _sec_name;
            set => Set(ref _sec_name, value);
        }

        public Rank Rank
        {
            get => _rank;
            set => Set(ref _rank, value);
        }

        public int GroupId
        {
            get => _groupid;
            set => Set(ref _groupid, value);
        }

        public bool IsAdmin
        {
            get => _is_admin;
            set => Set(ref _is_admin, value);
        }
        
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ImageSource Image
        {
            get => _image;
            set => Set(ref _image, value);
        }
        
        public string About
        {
            get => _about;
            set => Set(ref _about, value);
        }
    }
}
