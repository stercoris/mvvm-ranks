using Ranks.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranks.ViewModels
{
    class GroupsViewModel : ReactiveObject
    {
        public GroupsViewModel()
        {
            Groups = new List<GroupViewModel> (
                DataServices.Groups.GetGroups().Select(group => new GroupViewModel(this, group))
            );

            FoundGroups = Groups;

            CurrentlySelectedObject = Groups[0];
        }

        [Reactive] public List<GroupViewModel> Groups{ get; set; }
        [Reactive] public List<UserViewModel> SelectedGroup { get; set; }
        [Reactive] public List<GroupViewModel> FoundGroups { get; set; }
        /// <summary> Объект, определяющий какой элемент находится в правом окне(окно настройки)</summary>
        [Reactive] public ReactiveObject CurrentlySelectedObject { get; set; }

        public void SelectGroup(GroupViewModel group)
        { 
            SelectedGroup = new List<UserViewModel>(
                group.Group.Users.Select(user => new UserViewModel(this, user))
            );            
            CurrentlySelectedObject = group;

        }

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
                        return (group.Group.Name.Contains(_search_string));
                    });
                }
                this.RaiseAndSetIfChanged(ref _search_string, value);
                this.RaisePropertyChanged(nameof(FoundGroups));
            }
        }
    }
}
