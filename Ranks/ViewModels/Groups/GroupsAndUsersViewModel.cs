using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using RanksClient;
using System.Collections.ObjectModel;
using Group = RanksApi.IGetGroupsGQL.Response.GroupSelection;
using User = RanksApi.IGetGroupGQL.Response.GroupSelection.UserSelection;
using System.Threading.Tasks;

namespace Ranks.ViewModels
{
    class GroupsAndUsersViewModel : ReactiveObject
    {
        public GroupsAndUsersViewModel()
        {
            Task.Run(async () => {
                Groups = await LoadGroups();
                if (Groups.Count >= 0)
                {
                    SelectedGroup = Groups[0];
                    LastEditedObject = Groups[0];
                }
            });

            SelectGroupCommand = ReactiveCommand.Create<GroupViewModel>(
                groupvm => SelectedGroup = groupvm
            );

            SetEditableObject = ReactiveCommand.Create<ReactiveObject>(
                objectToEdit => CurrentlyEditableObject = objectToEdit
            );

            CmdChangeEditMenuVisibility = ReactiveCommand.Create(() =>
                CurrentlyEditableObject == null ?
                    CurrentlyEditableObject = LastEditedObject :
                    CurrentlyEditableObject = null
            );
        }

        [Reactive] public ObservableCollection<GroupViewModel> Groups { get; set; }

        #region Логика выбора группы и отображения пользователей
        
        private GroupViewModel _selected_group;
        public GroupViewModel SelectedGroup
        {
            get => _selected_group;
            set
            {
                if(_selected_group?.Group.id != value?.Group.id) {
                    _selected_group?.UnloadUsers();
                    value.LoadUsers();
                }
                this.RaiseAndSetIfChanged(ref _selected_group, value);
            }
        }

        private ICommand SelectGroupCommand { get; set; }
        #endregion

        #region Логика окна редактирования
        public ICommand CmdChangeEditMenuVisibility { get; set; }
        private ICommand SetEditableObject { get; set; }

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

        #region Логика поиска групп
        [Reactive] public string SearchString { get; set; }
        #endregion


        // TODO: Вынести нахер
        async private Task<ObservableCollection<GroupViewModel>> LoadGroups()
        {
            var GroupsAndUsers = await RanksApi.IGetGroupsGQL.SendQueryAsync(API.Client);
            List<Group> groups = GroupsAndUsers.Data.Groups;

            return (new ObservableCollection<GroupViewModel>(
                groups.Select(group => new GroupViewModel(group, SelectGroupCommand, SetEditableObject))
            ));
            
        }
    }
}
