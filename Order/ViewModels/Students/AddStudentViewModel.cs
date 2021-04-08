using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Linq;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    public class AddStudentViewModel : ReactiveObject
    {
        [Reactive] public Student Student { get; set; }
        [Reactive] public ICommand Save { get; set; }

        public AddStudentViewModel(ICommand saveUserCommand)
        {
            this.Student = new();
            this.Save = ReactiveCommand.Create(() =>
            {
                saveUserCommand.Execute(Student);
            });
        }
    }
}
