using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Media;

namespace Ranks.Model
{
    class Group : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _about;
        private ImageSource _image;
        private List<User> _users;

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

        public string About
        {
            get => _about;
            set => Set(ref _about, value);
        }

        public ImageSource Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        public List<User> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }
    }
}
