using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string About { get; set; }
        public Rank Rank { get; set; }
    }
}
