using RanksClient;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Windows.Input;
using User = RanksApi.IGetGroupGQL.Response.GroupSelection.UserSelection;


namespace Ranks.ViewModels
{
    class UserViewModel : ReactiveObject
    {
        [Reactive] public User User { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }
        public UserViewModel(User user, ICommand editCommand)
        {
            this.User = user;
            this.EditCommand = editCommand;
        }
    }
}
