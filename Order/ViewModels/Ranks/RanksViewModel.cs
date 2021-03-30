using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace Order.ViewModels
{
    class RanksViewModel : ReactiveObject
    {
        [Reactive] public ObservableCollection<RankItemViewModel> RankItems { get; set; }

        public RanksViewModel()
        {
            var ranks = new ObservableCollection<Rank>(DBProvider.DBContext.Ranks);
            RankItems = new ObservableCollection<RankItemViewModel>();
            foreach (var rank in ranks) RankItems.Add(new RankItemViewModel(rank));
        }
    }
}
