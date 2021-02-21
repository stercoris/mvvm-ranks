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
    class GroupsViewModel : ReactiveObject
    {
        public GroupsViewModel()
        {
            Groups = DataBase.Groups.GetGroups();
            FoundGroups = Groups;
            SelectGroupCommand = new Commands.SelectGroupCommand(this);
        }

        public Commands.SelectGroupCommand SelectGroupCommand { get; set; }

        [Reactive] public List<Group> Groups{ get; set; }
        [Reactive] public Group SelectedGroup { get; set; }
        [Reactive] public List<Group> FoundGroups { get; set; }

        public void SelectGroup(Group group)
        { SelectedGroup = group; }

        private string _search_string;
        public string SearchString
        {
            get => _search_string;
            set
            {
                if (String.IsNullOrWhiteSpace(_search_string))
                    FoundGroups = Groups;
                else
                {
                    FoundGroups = Groups.FindAll((group) =>
                    {
                        return (group.Name.Contains(_search_string));
                    });
                }
                this.RaiseAndSetIfChanged(ref _search_string, value);
                this.RaisePropertyChanged(nameof(FoundGroups));
            }
        }
    }
}
