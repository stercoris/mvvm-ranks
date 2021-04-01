using Order.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.Converters
{
    class SelectedGroupToStudentViewModelsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var group = value as GroupViewModel;
            var students = DataAccess.DBProvider.DBContext.Students
                .Where((student) => student.Group.Id == group.Group.Id);

            var studentsVMs = new ObservableCollection<UserViewModel>(
                students.Select(student => new UserViewModel(student, group.EditCommand))
            );
            return (studentsVMs);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
