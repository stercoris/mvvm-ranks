using DynamicData;
using Order.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.WPF.Converters
{
    class SelectedGroupToStudentViewModelsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var group = value as GroupViewModel;
            var studentsVMs = new ObservableCollection<StudentViewModel>();
            if (DataAccess.DBProvider.DBContext.Students.Any())
            {
                var students = DataAccess.DBProvider.DBContext.Students
                    .Where((student) => student.Group.Id == group.Group.Id)
                    .Select(student => new StudentViewModel(student, group.EditCommand));
                studentsVMs.AddRange(students);
            }
            return (studentsVMs);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
