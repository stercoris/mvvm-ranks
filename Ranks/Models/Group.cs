using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Windows.Media;

namespace Ranks.Models
{
    public class Group : ReactiveObject
    {

        [Reactive]
        public int Id
        { get; set;}

        [Reactive]
        public string Name
        { get; set; }

        [Reactive]
        public string About
        { get; set; }

        [Reactive]
        public ImageSource Image
        { get; set; }

        [Reactive]
        public List<User> Users
        { get; set; }
    }
}
