using GalaSoft.MvvmLight;
using Ranks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.ViewModel
{
    class RankItemViewModel : ViewModelBase
    {
        private Rank _rank;
        public Rank Rank
        {
            get => _rank;
            set => Set(ref _rank, value);
        }
        public RankItemViewModel(Rank rank)
        {
            Rank = rank;
        }
    }
}
