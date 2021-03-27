using ReactiveUI;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;

namespace Ranks.ViewModels
{
    class RanksViewModel : ReactiveObject
    {
        [Reactive] public ObservableCollection<RankItemViewModel> RankItems { get; set; }

        public RanksViewModel()
        {
            Task.Run(async () =>
            {
                var Ranks = (await DataAccess.RanksStorage.LoadRanks());
                var RankItemVMs = new ObservableCollection<RankItemViewModel>();
                foreach (var rank in Ranks) RankItemVMs.Add(new RankItemViewModel(rank));
                RankItems = new ObservableCollection<RankItemViewModel>(RankItemVMs);
            });
        }
    }
}
