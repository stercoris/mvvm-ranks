using DynamicData;
using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
                RankItems.Add(new RankItemViewModel(new Rank{Name="Новый Ранг"}, DeleteRank));
            });

            RankItems = new ObservableCollection<RankItemViewModel>(
                DBProvider.DBContext.Ranks.Select(rank => new RankItemViewModel(rank, DeleteRank))
            );
        }
    }
}
