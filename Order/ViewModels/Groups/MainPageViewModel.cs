using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    class MainPageViewModel : ReactiveObject
    {
        public MainPageViewModel()
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


            SaveGroupCommand = ReactiveCommand.Create<Group>((newGroup) =>
            {
                using(var dbContext = DataAccess.DBProvider.DBLocalContext)
                {
                    dbContext.Groups.Add(newGroup);
                    var newGroupVM = new GroupViewModel(newGroup, SelectGroupCommand, SetEditableObject, AddStudentCommand);
                    this.Groups.Add(newGroupVM);
                    CurrentlyEditableObject = newGroupVM;
                }
            });

            SaveStudentCommand = ReactiveCommand.Create<Student>((newStudent) =>
            {
                using (var dbContext = DataAccess.DBProvider.DBLocalContext)
                {
                    dbContext.Students.Add(newStudent);
                    newStudent.Rank = dbContext.Ranks.First();
                    newStudent.Group = this.SelectedGroup.Group;

                    var newStudentVM = new StudentViewModel(newStudent, SetEditableObject);
                    this.SelectedGroup.RaisePropertyChanging();
                    CurrentlyEditableObject = newStudentVM;
                }
            });


            AddStudentCommand = ReactiveCommand.Create(() => CurrentlyEditableObject = new AddStudentViewModel(SaveStudentCommand));
            AddGroupCommand = ReactiveCommand.Create(() => CurrentlyEditableObject = new AddGroupViewModel(SaveGroupCommand));

            if (DataAccess.DBProvider.DBContext.Groups.Any())
            {
                var groups = DataAccess.DBProvider.DBContext.Groups;
                Groups = new ObservableCollection<GroupViewModel>(
                    groups.Select(group => new GroupViewModel(group, SelectGroupCommand, SetEditableObject, AddStudentCommand))
                );
            }
            else
            {
                Groups = new ObservableCollection<GroupViewModel>();
            }
            if (Groups.Count > 0)
            {
                SelectedGroup = Groups[0];
                LastEditedObject = Groups[0];
            }
        }

        [Reactive] public ObservableCollection<GroupViewModel> Groups { get; set; }

        #region Логика выбора группы и отображения пользователей
        [Reactive] public GroupViewModel SelectedGroup { get; set; }
        private ICommand SelectGroupCommand { get; set; }
        #endregion

        #region Логика окна редактирования
        public ICommand CmdChangeEditMenuVisibility { get; set; }
        public ICommand SaveGroupCommand { get; set; }
        public ICommand SaveStudentCommand { get; set; }
        public ICommand AddGroupCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
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
