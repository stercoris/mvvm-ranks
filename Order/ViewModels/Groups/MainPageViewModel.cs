﻿using Order.DataAccess;
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    class MainPageViewModel : ReactiveObject
    {
        public MainPageViewModel()
        {


            SetEditableObject = ReactiveCommand.Create<ReactiveObject>(objectToEdit => CurrentlyEditableObject = objectToEdit);
            SelectGroupCommand = ReactiveCommand.Create<GroupViewModel>(groupvm => SelectedGroup = groupvm);

            CmdChangeEditMenuVisibility = ReactiveCommand.Create(() =>
                CurrentlyEditableObject = (CurrentlyEditableObject == null) ? LastEditedObject : null
            );

            DeleteUser = ReactiveCommand.Create<StudentViewModel>((student) =>
            {
                this.Students.Remove(student);
                DBProvider.DBContext.Students.Remove(student.User);
            });

            DeleteGroupCommand = ReactiveCommand.Create<GroupViewModel>(group =>
            {
                this.Groups.Remove(group);
                DBProvider.DBContext.Groups.Remove(group.Group);
            });

            AddGroupCommand = ReactiveCommand.Create(() =>
            {
                var newGroup = new Group();
                DataAccess.DBProvider.DBContext.Groups.Add(newGroup);
                var newGroupVM = new GroupViewModel(newGroup, SelectGroupCommand, SetEditableObject, AddStudentCommand, DeleteGroupCommand);
                this.Groups.Add(newGroupVM);
                CurrentlyEditableObject = newGroupVM;
            });

            AddStudentCommand = ReactiveCommand.Create(() =>
            {
                var newStudent = new Student { Group = this.SelectedGroup.Group };
                DataAccess.DBProvider.DBContext.Students.Add(newStudent);
                var newStudentVM = new StudentViewModel(newStudent, DeleteUser, SetEditableObject);
                this.Students.Add(newStudentVM);
                CurrentlyEditableObject = newStudentVM;
            });

            this.WhenAnyValue(t => t.SelectedGroup).WhereNotNull()
                .Select(group => DataAccess.DBProvider.DBContext.Students.Where(student => student.Group.Id == group.Group.Id)).WhereNotNull()
                .Select(students => students.Select(student => new StudentViewModel(student, DeleteUser, SetEditableObject)))
                .Select(studentsVMs => new ObservableCollection<StudentViewModel>(studentsVMs))
                .Subscribe((students) => Students = students);


            if (DataAccess.DBProvider.DBContext.Groups.Any())
            {
                var groups = DBProvider.DBContext.Groups;
                Groups = new ObservableCollection<GroupViewModel>(
                    groups.Select(group => new GroupViewModel(group, SelectGroupCommand, SetEditableObject, AddStudentCommand, DeleteGroupCommand))
                );
                SelectedGroup = Groups.First();
                LastEditedObject = Groups.First();
            }
        }
        [Reactive] public ObservableCollection<StudentViewModel> Students { get; set; } = new ObservableCollection<StudentViewModel>();
        [Reactive] public ObservableCollection<GroupViewModel> Groups { get; set; } = new ObservableCollection<GroupViewModel>();

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
        private ICommand DeleteUser { get; set; }
        public ICommand DeleteGroupCommand { get; set; }

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
