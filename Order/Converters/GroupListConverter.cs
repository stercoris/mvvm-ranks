using System.Globalization;
using System.Windows.Data;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Order.WPF.Converters
{

    public class GroupListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //я пытался найти способ обратиться к уже существующему списку групп, но я не смог. Так что пока будет так
            var groups = DataAccess.DBProvider.DBContext.Groups;
            ObservableCollection<string> groupsName = new();
            foreach (var x in groups)
                groupsName.Add(x.Name);
            return groupsName;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}

