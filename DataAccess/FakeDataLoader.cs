using Order.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DataAccess
{
    public static class FakeDataLoader
    {
        public static void Load(OrderContext dbContext)
        {
            var groups = new List<Group>();

            dbContext.Groups.Add(new Group
            {
                About = "Крутая группа ТПК", 
                Name = "Вп-31",
            });

            dbContext.Groups.Add(new Group
            {
                About = "Группа ТПК №2",
                Name = "Вп-21",
            });

            dbContext.Groups.Add(new Group
            {
                About = "Группа ТПК",
                Name = "Вп-11",
            });

            dbContext.Ranks.Add(new Rank
            {
                Name = "Иди нахуй говно",
            });

            dbContext.Students.Add(new Student
            {
                About = "Дмитрий, блин родин!!", 
                Name = "Дмитрий", 
                SecondName = "Родин",
                Group = new Group
                {
                    About = "Ебать это ОН",
                    Name = "Группа социального движения 'Анти-савощенко'",
                },
                Rank = new Rank
                {
                    Name = "Не Иди нахуй говно",
                },
            });
            dbContext.SaveChanges();
        }
    }
}
