using RanksClient;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group = RanksApi.IGetGroupsGQL.Response.GroupSelection;

namespace Ranks.DataAccess
{
    class GroupsStorage
    {
        [Reactive] public static ObservableCollection<Group> Groups { get; private set; }
        public static async Task<ObservableCollection<Group>> LoadGroups()
        {
            if (Groups == null)
            {
                Groups = new ObservableCollection<Group>((await RanksApi.IGetGroupsGQL.SendQueryAsync(API.Client)).Data.Groups);
            }
            return await Task.FromResult(Groups);
        }
    }
}
