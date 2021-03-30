using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Order.DataAccess;

namespace Ranks.ViewModels
{
    class GroupsAndUsersViewModel : ReactiveObject
    {
        public GroupsAndUsersViewModel()
        {
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

            var groups = DBProvider.DBContext.Groups;
            Groups = new ObservableCollection<GroupViewModel>(
                // Логика не совсем понятная, 
                // но я передаю группу, команду выбора группы(отображение пользователей), 
                // команду выбора объекта, который редактирутся в контроллер
                groups.Select(group => new GroupViewModel(group, SelectGroupCommand, SetEditableObject))
            );

            if (Groups.Count > 0)
            {
                SelectedGroup = Groups[0];
                LastEditedObject = Groups[0];
            }
        }

        [Reactive] public ObservableCollection<GroupViewModel> Groups { get; set; }

        #region Логика выбора группы и отображения пользователей
        private GroupViewModel _selected_group;
        public GroupViewModel SelectedGroup
        {
            get => _selected_group;
            set
            {
                if (_selected_group?.Group.Id != value?.Group.Id)
                {
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

    }
}
