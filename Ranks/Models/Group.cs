using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Windows.Media;

namespace Ranks.Models
{
    public class Group : ReactiveObject
    {
        [Reactive] public int Id { get; set;}
        [Reactive] public string Name { get; set; }
        [Reactive] public string About { get; set; }
        [Reactive] public List<User> Users { get; set; }
        public ImageSource hqImage
        {get => Services.ImageConverter.toImage(DataAccess.Groups.GetBase64Image(Id), 960, 540);}
        public ImageSource lqImage
        {get => Services.ImageConverter.toImage(DataAccess.Groups.GetBase64Image(Id), 90, 45);}
    }
}
