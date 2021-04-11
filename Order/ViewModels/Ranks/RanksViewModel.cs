using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Order.WPF.ViewModels
{
    class RanksViewModel : ReactiveObject
    {
        [Reactive] public ObservableCollection<RankItemViewModel> RankItems { get; set; }
        public ICommand DeleteRank { get; set; }
        public ICommand CreateRank { get; set; }

        public RanksViewModel()
        {
            /// TODO: Сделать сохранение в бд
            DeleteRank = ReactiveCommand.Create<RankItemViewModel>((rank) =>
            {
                RankItems.Remove(rank);
            });
            CreateRank = ReactiveCommand.Create(() =>
            {
                //DataAccess.DBProvider.DBContext.Ranks.Add
                RankItems.Add(new RankItemViewModel(new Rank{Name="Новый Ранг"}, DeleteRank));
            });
            var ranks = new ObservableCollection<Rank>(DBProvider.DBContext.Ranks);
            RankItems = new ObservableCollection<RankItemViewModel>();
            foreach (var rank in ranks) RankItems.Add(new RankItemViewModel(rank, DeleteRank));
        }
    }
}
