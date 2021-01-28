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

        public delegate void GotoUserGroupHandler(int groupid);
        public event GotoUserGroupHandler GroupUsersChanging;

        public delegate void GotoGroupHandler(Group group);
        public event GotoGroupHandler GotoGroupChanging;

        /// <summary>
        /// Переводит активную страницу на "Добавить группу"
        /// </summary>
        /// <param name="groupid">id группы</param>
        public void GotoGroup(Group group)
        {
            GotoGroupChanging(group);
        }
        /// <summary>
        /// Переводит активную страницу на "Профиль", с выбранным пользователем
        /// </summary>
        /// <param name="userid">id пользователя</param>
        public void GotoUser(int userid)
        {
            UserChanging(userid);
        }
        /// <summary>
        /// Переводит активную страницу на выбранную
        /// </summary>
        /// <param name="page">выбранный id страницы</param>
        public void ChangePage(Layouts page)
        {
            PageChanging(page);
        }
        /// <summary>
        /// Переводит активную страницу на "Польльзователи", в выбором группы.
        /// </summary>
        /// <param name="groupid">выбирает эту группу в правом верхнем меню</param>
        public void GotoGroupUsers(int groupid)
        {
            GroupUsersChanging(groupid);
        }
    }
}
