using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;


namespace Order.WPF.ViewModels
{
    class StudentViewModel : ReactiveObject
    {
        [Reactive] public Student User { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }

        public StudentViewModel(Student user, ICommand editCommand = null)
        {
            this.User = user;
            this.EditCommand = editCommand;
        }
    }
}
