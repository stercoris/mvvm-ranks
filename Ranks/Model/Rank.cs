using GalaSoft.MvvmLight;
namespace Ranks.Model
{
    public class Rank : ViewModelBase
    {
        private int _id;
        private string _name;

        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }
}
