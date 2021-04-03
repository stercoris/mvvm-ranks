using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    class AddStudentViewModel : ReactiveObject
    {
        [Reactive] public Student Student { get; set; }
        [Reactive] public ICommand Save { get; set; }

        AddStudentViewModel()
        {
            this.Student = new();
            this.Save = ReactiveCommand.Create(() =>
            {
                DataAccess.DBProvider.DBContext.Students.Add(Student);
            });
        }
    }
}
