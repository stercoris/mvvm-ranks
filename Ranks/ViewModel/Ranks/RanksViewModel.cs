using GalaSoft.MvvmLight;
using Ranks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.ViewModel
{
    class RanksViewModel : ViewModelBase
    {
        public List<RankItemViewModel> RankItems { get; private set; }
        public RanksViewModel()
        {
            RankItems = new List<RankItemViewModel>(DataBase.Ranks.GetAll().Select(rank => new RankItemViewModel(rank)));
        }
    }
}
