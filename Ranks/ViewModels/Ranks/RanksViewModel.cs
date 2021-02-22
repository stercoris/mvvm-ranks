using Ranks.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.ViewModels
{
    class RanksViewModel : ReactiveObject
    {
        public List<RankItemViewModel> RankItems { get; private set; }
        public RanksViewModel()
        {
            RankItems = new List<RankItemViewModel>(
                DataServices.Ranks.GetAll().Select(rank => new RankItemViewModel(rank))
            );
        }
    }
}
