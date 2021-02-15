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
    class User : INotifyPropertyChanged
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
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string SecondName
        {
            get => _sec_name;
            set
            {
                if (value == _sec_name) return;
                _sec_name = value;
                OnPropertyChanged();
            }
        }

        public Rank Rank
        {
            get => _rank;
            set
            {
                if (value == _rank) return;
                _rank = value;
                OnPropertyChanged();
            }
        }

        public Group Group
        {
            get => _group;
            set
            {
                if (value == _group) return;
                _group = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdmin
        {
            get => _is_admin;
            set
            {
                if (value == _is_admin) return;
                _is_admin = value;
                OnPropertyChanged();
            }
        }
        
        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage Picture
        {
            get => _piture;
            set
            {
                if (value == _piture) return;
                _piture = value;
                OnPropertyChanged();
            }
        }
        
        public string About
        {
            get => _about;
            set
            {
                if (value == _about) return;
                _about = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
