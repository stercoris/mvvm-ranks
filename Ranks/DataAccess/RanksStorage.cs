using RanksClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rank = RanksApi.IGetRanksGQL.Response.RankSelection;

namespace Ranks.DataAccess
{
    public class RanksStorage
    {
        //public RanksStorage()
        //{
        //    Task.Run(async () => Ranks = await LoadRanks());
        //}

        public static ObservableCollection<Rank> Ranks { get; private set; }
        public static async Task<ObservableCollection<Rank>> LoadRanks()
        {
            if (Ranks == null)
            {
                Ranks = new ObservableCollection<Rank>((await RanksApi.IGetRanksGQL.SendQueryAsync(API.Client)).Data.Ranks);
            }
            return await Task.FromResult(Ranks);
        }
    }
}
