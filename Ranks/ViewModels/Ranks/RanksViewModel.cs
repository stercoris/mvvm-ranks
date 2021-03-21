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
        API api = new API("http://localhost:8000/graph");

        public RanksViewModel()
        {
            new Thread(async () =>
            {
                RankItems = new List<RankItemViewModel>(
                (await api.RankResolver.GetRanks()).Select(rank => new RankItemViewModel(rank))
            );
            }).Start();
            
        }
    }
}
