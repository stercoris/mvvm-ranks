using Ranks.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.ViewModel
{
    class RankItemViewModel : ReactiveObject
    {
        [Reactive]
        public Rank Rank
        { get; set; }

        public RankItemViewModel(Rank rank)
        {
            Rank = rank;
        }
    }
}
