using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Windows.Input;


namespace Order.WPF.ViewModels
{
    class StudentViewModel : ReactiveObject
    {
        [Reactive] public Student User { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }
        public ICommand ChangeRank { get; set; }

        public StudentViewModel(Student user, ICommand editCommand = null)
        {
            this.User = user;
            this.EditCommand = editCommand;
            ChangeRank = ReactiveCommand.Create((string dif) =>
            {
                int rankDif = System.Convert.ToInt32(dif);
                User.Rank = DataAccess.DBProvider.DBContext.Ranks
                    .Find(this.User.Rank.Id + rankDif)
                    ??User.Rank;
                this.RaisePropertyChanged(nameof(User));
            });
        }
    }
}
