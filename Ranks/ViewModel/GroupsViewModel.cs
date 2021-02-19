using GalaSoft.MvvmLight;
using Ranks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.ViewModel
{
    class GroupsViewModel : ViewModelBase
    {
        public GroupsViewModel()
        {
            Groups = DataBase.Groups.GetGroups();
            SelectGroupCommand = new Commands.SelectGroupCommand(this);
            FoundGroups = Groups;
        }

        public Commands.SelectGroupCommand SelectGroupCommand { get; set; }
        private List<Group> _groups;
        public List<Group> Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }
        private Group _selected_group;
        public Group SelectedGroup
        {
            get => _selected_group;
            set => Set(ref _selected_group, value);
        }
        public void SelectGroup(Group group)
        { SelectedGroup = group; }

        private string _search_string;
        public string SearchString
        {
            get => _search_string;
            set
            {
                Set(ref _search_string, value);
                if (String.IsNullOrWhiteSpace(_search_string))
                    FoundGroups = Groups;
                else
                {
                    FoundGroups = Groups.FindAll((group) =>
                    {
                        return (group.Name.Contains(_search_string));
                    });
                }
                RaisePropertyChanged(nameof(FoundGroups));
            }
        }
        private List<Group> _found_groups;
        public List<Group> FoundGroups
        {
            get => _found_groups;
            set => Set(ref _found_groups, value);
        }
    }
}
