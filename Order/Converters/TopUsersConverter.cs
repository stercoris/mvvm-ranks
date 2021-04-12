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

            var students = DataAccess.DBProvider.DBContext.Students
                .Where(student => student.Group.Id == groupId).ToList();

            if (!students.Any(student => student.Rank != null))
            {
                return (null);
            }

            var studentVMs = students
                .OrderBy(user => user.Rank.Id).Reverse()
                .Select(student => new StudentViewModel(student, null)).ToList();

            var topThree = studentVMs.GetRange(0, (studentVMs.Count > 3) ? 3 : studentVMs.Count);

            return (new ObservableCollection<StudentViewModel>(topThree));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
