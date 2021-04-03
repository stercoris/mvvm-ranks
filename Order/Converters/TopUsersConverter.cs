using Order.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.WPF.Converters
{

    public class TopUsersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var groupId = (value as DataAccess.Models.Group).Id;
            var studentVMs = DataAccess.DBProvider.DBContext.Students
                .Where(student => student.Group.Id == groupId).ToList()
                .OrderBy(user => user.Rank.Id)
                .Reverse()
                .Select(student => new StudentViewModel(student, null)).ToList();

            return (new ObservableCollection<StudentViewModel>(
                studentVMs.GetRange(0, (studentVMs.Count > 3) ? 3 : studentVMs.Count)
            ));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
