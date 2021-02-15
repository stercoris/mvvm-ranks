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
    class Group : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _about;
        private BitmapImage _piture;

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


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
