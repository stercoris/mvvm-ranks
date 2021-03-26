using RanksClient;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Group = RanksApi.IGetGroupsGQL.Response.GroupSelection;

namespace Ranks.ViewModels
{
    class GroupViewModel : ReactiveObject
    {
        [Reactive] public Group Group { get; set; }
        [Reactive] public ImageSource Picture { get; set; }

        // Каллбек для фетча пользователей группы
        public ICommand ShowUsersCommand { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }

        public GroupViewModel(
            Group group,
            ICommand groupSelectCommand,
            ICommand groupEditCommand
        ) {
            this.Group = group;
            ShowUsersCommand = groupSelectCommand;
            EditCommand = groupEditCommand;
        }
    }
}
