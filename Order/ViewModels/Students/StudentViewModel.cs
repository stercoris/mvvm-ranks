using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Windows;
using System.Windows.Input;
using Order.WPF.ViewModels;


namespace Order.WPF.ViewModels
{
    class StudentViewModel : ReactiveObject
    {
        [Reactive] public Student User { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }
        public ICommand ChangeRank { get; set; }
        public ICommand DeleteUserCommand { get; set; }

        public StudentViewModel(Student user, ICommand DeleteUser, ICommand editCommand = null)
        {
            this.User = user;
            this.EditCommand = editCommand;
            ChangeRank = ReactiveCommand.Create((string dif) =>
            {
                var ranks = DataAccess.DBProvider.DBContext.Ranks.ToList();
                int index = ranks.IndexOf(User.Rank);
                int rankDif = System.Convert.ToInt32(dif);
                try
                {
                    User.Rank = ranks
                    .ElementAt(index + rankDif)
                    ?? User.Rank;
                }
                catch{ }
                this.RaisePropertyChanged(nameof(User));
            });
            this.DeleteUserCommand = ReactiveCommand.Create(() =>
            {
                DeleteUser.Execute(this);
            });

        }
    }
}
