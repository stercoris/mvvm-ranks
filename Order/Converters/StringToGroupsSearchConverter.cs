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

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            string search = ((string)value[0])?.ToLower();
            var groups = ((ObservableCollection<GroupViewModel>)value[1])?? new ObservableCollection<GroupViewModel>();

            //Тупо, но легче коммент оставить -> value[1] = ObservableCollection<GroupViewModel>
            if (value[1] is null || search is null)
            {
                return groups;
            }

            var founded = groups.ToList()
                .FindAll((group) => group.Group.Name.ToLower().Contains(search));

            return (founded);


        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
