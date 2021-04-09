using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
                CurrentlyEditableObject = (CurrentlyEditableObject == null) ? LastEditedObject : null
            );


            SaveGroupCommand = ReactiveCommand.Create<Group>((newGroup) =>
            {
                new Task(async () =>
                {
                    await DataAccess.DBProvider.DBContext.Groups.AddAsync(newGroup);

                    await DataAccess.DBProvider.DBContext.SaveChangesAsync();
                    var newGroupVM = new GroupViewModel(newGroup, SelectGroupCommand, SetEditableObject, AddStudentCommand);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        this.Groups.Add(newGroupVM);
                        CurrentlyEditableObject = newGroupVM;

                    });
                }).Start();
            });

            SaveStudentCommand = ReactiveCommand.Create<Student>((newStudent) =>
            {
                new Task(async () =>
                {
                    DataAccess.DBProvider.DBContext.Students.Add(newStudent);

                    newStudent.Rank = DBProvider.DBContext.Ranks.First();
                    newStudent.Group = this.SelectedGroup.Group;
                    await DataAccess.DBProvider.DBContext.SaveChangesAsync();

                    this.RaisePropertyChanged(nameof(SelectedGroup));
                    var newStudentVM = new StudentViewModel(newStudent, SetEditableObject);
                    CurrentlyEditableObject = newStudentVM;

                }).Start();
            });


            AddStudentCommand = ReactiveCommand.Create(() => CurrentlyEditableObject = new AddStudentViewModel(SaveStudentCommand));
            AddGroupCommand = ReactiveCommand.Create(() => CurrentlyEditableObject = new AddGroupViewModel(SaveGroupCommand));

            if (DataAccess.DBProvider.DBContext.Groups.Any())
            {
                var groups = DBProvider.DBContext.Groups;
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
