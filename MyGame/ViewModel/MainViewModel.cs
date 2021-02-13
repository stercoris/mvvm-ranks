using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ranks.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private Page GroupList;
        private Page GroupProfile;
        private Page User;
        private Page UserProfile;
        private Page RankList;

        public MainViewModel()
        {
            GroupList = new View.Groups();
        }

        private string _Title = "Звания";

        public string TestText
        {
            get
            {
                return _Title;
            }
        }
    }
}
