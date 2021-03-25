using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
using RanksClient;
using System.Threading;

namespace Ranks.ViewModels
{
    class RanksViewModel : ReactiveObject
    {
        public List<RankItemViewModel> RankItems { get; private set; }

        public RanksViewModel()
        {
           
            
        }
    }
}
