using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;


namespace Order.WPF.ViewModels
{
    class RanksViewModel : ReactiveObject
    {
        [Reactive] public ObservableCollection<RankItemViewModel> RankItems { get; set; }
        public ICommand DeleteRank { get; set; }
        public ICommand CreateRank { get; set; }
        public ICommand ChangeRanksPosition { get; set; }

        public RanksViewModel()
        {
            ChangeRanksPosition = ReactiveCommand.Create<RankItemViewModel>((rank) =>
            {
                try
                {
                    int index = RankItems.IndexOf(rank);
                    Swap(RankItems, index, index + 1);
                    Swap(DBProvider.DBContext.Ranks.ToList(), index, index + 1);
                }
                catch { }
                //MessageBox.Show("" + RankItems.IndexOf(rank));
            });
            DeleteRank = ReactiveCommand.Create<RankItemViewModel>((rank) =>
            {
                DBProvider.DBContext.Ranks.Remove(rank.Rank);
                RankItems.Remove(rank);
            });
            CreateRank = ReactiveCommand.Create(() =>
            {
                var newRank = new Rank { Name = "Новый Ранг" };
                DBProvider.DBContext.Ranks.Add(newRank);
                RankItems.Add(new RankItemViewModel(newRank, DeleteRank, ChangeRanksPosition));
            });

            RankItems = new ObservableCollection<RankItemViewModel>(
                DBProvider.DBContext.Ranks.Select(rank => new RankItemViewModel(rank, DeleteRank, ChangeRanksPosition))
            );
        }
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}