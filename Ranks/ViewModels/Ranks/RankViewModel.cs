using ReactiveUI;
using ReactiveUI.Fody.Helpers;

class Rank
{

}

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
