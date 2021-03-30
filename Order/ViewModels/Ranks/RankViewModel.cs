using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;


namespace Order.ViewModels
{
    class RankItemViewModel : ReactiveObject
    {
        [Reactive] public Rank Rank { get; set; }

        public RankItemViewModel(Rank rank)
        {
            Rank = rank;
        }
    }
}
