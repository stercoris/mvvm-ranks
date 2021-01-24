using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ranks
{
    public partial class Frame : UserControl
    {
        public delegate void ChangePageHandler(Layouts page);
        public event ChangePageHandler PageChanging;

        public delegate void GotoUserHandler(int userid);
        public event GotoUserHandler UserChanging;

        public delegate void GotoGroupHandler(int groupid);
        public event GotoGroupHandler GroupUsersChanging;

        public void GotoUser(int userid)
        {
            UserChanging(userid);
        }
        public void ChangePage(Layouts page)
        {
            PageChanging(page);
        }
        public void GotoGroupUsers(int groupid)
        {
            GroupUsersChanging(groupid);
        }
    }
}
