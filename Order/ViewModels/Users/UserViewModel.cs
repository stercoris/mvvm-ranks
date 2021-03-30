using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;


namespace Order.ViewModels
{
    class UserViewModel : ReactiveObject
    {
        [Reactive] public Student User { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }
        public UserViewModel(Student user, ICommand editCommand)
        {
            this.User = user;
            this.EditCommand = editCommand;
        }
    }
}
