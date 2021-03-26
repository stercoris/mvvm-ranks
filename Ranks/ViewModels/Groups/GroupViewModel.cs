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
        [Reactive] public GroupsAndUsersViewModel groupsvm { get; set; }
        [Reactive] public ImageSource Picture { get; set; }
        public ICommand ShowUsersCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public GroupViewModel(GroupsAndUsersViewModel groupsvm, Group group)
        {
            this.Group = group;
            this.groupsvm = groupsvm;
            // Требуется вынести в родительский класс, зачем создавать так много экземпляров команды?????????????
            ShowUsersCommand = ReactiveCommand.Create(() => groupsvm.SelectedGroup = this);
            EditCommand = ReactiveCommand.Create(() => groupsvm.CurrentlyEditableObject = this);
            LoadImage();
        }
        // TODO: Вынести нахер
        async private Task LoadImage()
        {
            var pic = (await RanksApi.IGetGroupImageGQL.SendQueryAsync(API.Client, new RanksApi.IGetGroupImageGQL.Variables { id = this.Group.id })).Data.Group.picture;
            this.Picture = Services.ImageConverter.toImage(pic, 250, 100);
        }

        // TODO: Удалить ICommnand и сделать через ReactiveCommand.Create
        public void Select()
        {
            groupsvm.SelectedGroup = this;
        }
    }
}
