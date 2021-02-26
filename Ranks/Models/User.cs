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
        [Reactive] public string About { get; set; }
        public ImageSource hqImage
        {get => Services.ImageConverter.toImage(DataAccess.Users.GetBase64Image(Id), 960, 540);}

        public ImageSource lqImage
        // Панелька, отображающая пользователя в юи сейчас примерно 180 на 90, но в последующее время надо будет добавить 
        // конвертер, которы будет принимать только высоту или ширину(изображения могут быть разного соотношения сторон)
        { get => Services.ImageConverter.toImage(DataAccess.Users.GetBase64Image(Id), 180, 90);} 

    }
}
