using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    class RankItemViewModel : ReactiveObject
    {
        [Reactive] public Rank Rank { get; set; }
        public ICommand DeleteRankCommand { get; set; }
        public ICommand ChangeRanksPositionCommand { get; set; }

        public RankItemViewModel(Rank rank, ICommand DeleteRank, ICommand ChangeRanksPosition)
        {
            Rank = rank;
            this.ChangeRanksPositionCommand = ReactiveCommand.Create(() =>
            {
                ChangeRanksPosition.Execute(this);
            });
            this.DeleteRankCommand = ReactiveCommand.Create(() =>
            {
                DeleteRank.Execute(this);
            });
        }
    }
}
