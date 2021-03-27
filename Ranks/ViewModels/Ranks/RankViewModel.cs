using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Rank = RanksApi.IGetRanksGQL.Response.RankSelection;


namespace Ranks.ViewModels
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
