using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Ranks.Model
{
    class Group : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _about;
        private BitmapImage _piture;
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

        public BitmapImage Picture
        {
            get => _piture;
            set => Set(ref _piture, value);
        }

        public List<User> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }
    }
}
