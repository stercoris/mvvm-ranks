
using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    class AddGroupViewModel : ReactiveObject
    {
        [Reactive] public Group Group { get; set; }
        public ICommand Save { get; set; }
        public AddGroupViewModel(ICommand saveGroupCommand)
        {
            this.Group = new();
            this.Save = ReactiveCommand.Create(() =>
            {
                saveGroupCommand.Execute(this.Group);
            });
        }
    }
}
