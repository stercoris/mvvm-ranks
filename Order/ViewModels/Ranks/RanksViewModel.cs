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
            //ObservableCollection<Rank> ranks = DataAccess.RanksStorage.Ranks;
            //RankItems = new ObservableCollection<RankItemViewModel>();
            //foreach (var rank in ranks) RankItems.Add(new RankItemViewModel(rank));
        }
    }
}
