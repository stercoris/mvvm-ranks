using Order.DataAccess;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Order.WPF.Converters
{

    public class StatisticSizeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rankId = System.Convert.ToInt32(value);
            if(!DBProvider.DBContext.Students.Any(student => student.Rank != null))
            {
                return (null);
            }

            var studentsRanks = DBProvider.DBContext.Students
                .Where(student => student.Rank != null)
                .Select(student => student.Rank.Id)
                .ToList();
            int selectedStudents = studentsRanks
                .Where(studentRank => studentRank == rankId).Count();
            int width = System.Convert.ToInt32((selectedStudents / (double)studentsRanks.Count) * 180);
            return width;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}
