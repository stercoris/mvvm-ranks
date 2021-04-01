using DynamicData;
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
            var studentsVMs = new ObservableCollection<UserViewModel>();
            if(DataAccess.DBProvider.DBContext.Students.Count() > 0)
            {
                var students = DataAccess.DBProvider.DBContext.Students
                    .Where((student) => student.Group.Id == group.Group.Id)
                    .Select(student => new UserViewModel(student, group.EditCommand));
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
