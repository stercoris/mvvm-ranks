using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Media;

namespace Ranks.Models
{
    public class User : ReactiveObject
    {
        [Reactive] public int Id { get; set; }
        [Reactive] public string Name { get; set; }
        [Reactive] public string SecondName { get; set; }
        [Reactive] public Rank Rank { get; set; }
        [Reactive] public int GroupId { get; set; }
        [Reactive] public bool IsAdmin { get; set; }
        [Reactive] public string Password { get; set; }

        private ImageSource _image;

        public ImageSource Image
        {
            get => DataBase.Users.GetImageByUid(Id);
            set { 
                this.RaiseAndSetIfChanged(ref _image, value);
                DataBase.Users.Update(this);
            }
        }
        [Reactive] public string About { get; set; }

    }
}
