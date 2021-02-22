using Ranks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ranks.DataServices
{
    interface IUserDataService
    {
        List<User> GetAll();
        User GetById(int id);
        ImageSource GetImage();
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool DeleteById(int id);

    }
}
