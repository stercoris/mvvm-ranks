using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Ranks.Models
{
    public class Rank : ReactiveObject
    {
        [Reactive] public int Id { get; set; }

        [Reactive] public string Name { get; set; }

    }
}
