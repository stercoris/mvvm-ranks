using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Order.DataAccess;

namespace Order.Converters
{

    public class StatisticSizeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rankId = System.Convert.ToInt32(value);
            var students = DBProvider.DBContext.Students
                .Select((student)=>student.Rank.Id).ToList();
            double count = 0;
            double studentsCount = 0;
            foreach (var student in students)
            {
                if (student == rankId) count++;
                studentsCount++;
            }
            int width = System.Convert.ToInt32((count/ studentsCount) * 400);
            return width;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value);
        }
    }

}
