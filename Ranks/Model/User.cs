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
    class User : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _sec_name;
        private Group _group;
        private Rank _rank;
        private bool _is_admin;
        private string _password;
        private BitmapImage _piture;
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

        public Group Group
        {
            get => _group;
            set => Set(ref _group, value);
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

        public BitmapImage Picture
        {
            get => _piture;
            set => Set(ref _piture, value);
        }
        
        public string About
        {
            get => _about;
            set => Set(ref _about, value);
        }
    }
}
