using Order.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.Converters
{
    public class StringToGroupsSearchConverter : IMultiValueConverter
    {

        // TODO: Переписать в нормальном виде
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value[1] != null)
            {
                if (value[0] == null || (value[0] as string).Length == 0)
                {
                    return (value[1]);
                }
                string search = ((string)value[0]).ToLower();
                var groups = ((ObservableCollection<GroupViewModel>)value[1]);

                return (groups.ToList().FindAll((group) =>
                {
                    string groupName = group.Group.Name.ToLower();
                    string[] fixes = groupName.Split('-');
                    if (search.Contains(fixes[0]) || search.Contains(fixes[1]))
                    {
                        return (true);
                    }
                    return (false);
                }));
            }
            return new ObservableCollection<GroupViewModel>();


        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
