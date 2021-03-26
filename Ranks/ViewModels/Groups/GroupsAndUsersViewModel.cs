using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using RanksClient;
using System.Collections.ObjectModel;
using Group = RanksApi.IGetGroupsAndUsersWithoutPicturesGQL.Response.GroupSelection;
using System.Threading.Tasks;

namespace Ranks.ViewModels
{
    class GroupsAndUsersViewModel : ReactiveObject
    {
        public GroupsAndUsersViewModel()
        {
            LoadGroups();


            CmdChangeEditMenuVisibility = ReactiveCommand.Create(
                () => CurrentlyEditableObject == null ? 
                    CurrentlyEditableObject = LastEditedObject : CurrentlyEditableObject = null);
        }

        [Reactive] public ObservableCollection<GroupViewModel> Groups { get; set; }
        [Reactive] public GroupViewModel SelectedGroup { get; set; }
        [Reactive] public ObservableCollection<GroupViewModel> FoundGroups { get; set; }


        #region Логика окна редактирования
        public ICommand CmdChangeEditMenuVisibility { get; set; }

        public ReactiveObject LastEditedObject;

        private ReactiveObject _currently_editable_object;
        public ReactiveObject CurrentlyEditableObject
        {
            get => _currently_editable_object;
            set
            {
                if (value != null) LastEditedObject = value;
                this.RaiseAndSetIfChanged(ref _currently_editable_object, value);
            }
        }
        #endregion

        private string _search_string;
        public string SearchString
        {
            get => _search_string;
            set
            {
                this.RaiseAndSetIfChanged(ref _search_string, value);
                if (String.IsNullOrWhiteSpace(value))
                    FoundGroups = Groups;
                else
                {
                    FoundGroups = new ObservableCollection<GroupViewModel>(
                        Groups.Where((group) => group.Group.name.Contains(value))
                    );
                }
                this.RaisePropertyChanged(nameof(FoundGroups));
            }
        }

        async private Task LoadGroups()
        {
            var GroupsAndUsers = await RanksApi.IGetGroupsAndUsersWithoutPicturesGQL.SendQueryAsync(API.Client);
            List<Group> groups = GroupsAndUsers.Data.Groups;

            Groups = new ObservableCollection<GroupViewModel>(
                groups.Select(group => new GroupViewModel(this, group))
            );
            FoundGroups = Groups;
            if (FoundGroups.Count >= 0)
            {
                SelectedGroup = FoundGroups[0];
                LastEditedObject = FoundGroups[0];
            }
        }
    }
}
