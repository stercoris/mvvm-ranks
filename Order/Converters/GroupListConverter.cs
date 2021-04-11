using System.Globalization;
using System.Windows.Data;
using System;
using System.Linq;

namespace Order.WPF.Converters
{

    public class GroupListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //я пытался найти способ обратиться к уже существующему списку групп, но я не смог. Так что пока будет так
            // Вместо:
            // var groups = DataAccess.DBProvider.DBContext.Groups;
            // ObservableCollection<string> groupsName = new();
            // foreach (var x in groups)
            //     groupsName.Add(x.Name);
            // Используй:
            var groupsNames = DataAccess.DBProvider.DBContext.Groups
                .Select(group => group.Name).ToList();
            // Всё более читаемо, я вижу, что из бдшки выбираю только имена, и потом переводу их всё в лист

            return groupsNames;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}

