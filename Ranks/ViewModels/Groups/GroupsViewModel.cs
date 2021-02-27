using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Ranks.ViewModels
{
    class GroupsViewModel : ReactiveObject
    {
        public GroupsViewModel()
        {
            Groups = new List<GroupViewModel>(
                DataAccess.Groups.GetGroups().Select(group => new GroupViewModel(this, group))
            );

            FoundGroups = Groups;

            if (FoundGroups.Count >= 0)
            {
                SelectedGroup = FoundGroups[0];
                LastEditedObject = FoundGroups[0];
            }
            CmdChangeEditMenuVisibility = ReactiveCommand.Create(
                () => CurrentlyEditableObject == null ? 
                    CurrentlyEditableObject = LastEditedObject : CurrentlyEditableObject = null);
        }

        [Reactive] public List<GroupViewModel> Groups { get; set; }
        [Reactive] public GroupViewModel SelectedGroup { get; set; }
        [Reactive] public List<GroupViewModel> FoundGroups { get; set; }

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
                    FoundGroups = Groups.FindAll((group) =>
                    {
                        return (group.Group.Name.Contains(value));
                    });
                }
                this.RaisePropertyChanged(nameof(FoundGroups));
            }
        }
    }
}
