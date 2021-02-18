using Ranks.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.DataBase
{
    class Groups
    {

        static private SQLiteConnection connection = DBConnection.connection;
        static private SQLiteCommand m_sqlCmd;
        static private SQLiteDataReader rdr;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public List<Group> GetGroups()
        {
            string sqlQuery = $"SELECT * FROM groups";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();


            List<User> users = Users.GetAll();
            List<Group> groups = new List<Group> { };
            while (rdr.Read())
            {
                Group group = new Group
                {
                    Name = rdr["name"].ToString(),
                    Id = Convert.ToInt32(rdr["id"]),
                    Image = Services.ImageConverter.toImage(rdr["pic"].ToString()),
                    About = rdr["about"].ToString(),
                };
                group.Users = users.FindAll((user) => user.GroupId == group.Id);

                groups.Add(group);
            }
            return (groups);
        }
        /// <summary>
        /// Получает имя группы через ID
        /// </summary>
        /// <param name="groupId">ID группы</param>
        /// <returns>Группа(название)</returns>
        static public Group GroupById(int groupId)
        {
            string sqlQuery = $"SELECT * FROM groups WHERE id = {groupId}";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
                return new Group {
                    Name = rdr["name"].ToString(),
                    About = rdr["about"].ToString(),
                    Image = Services.ImageConverter.toImage(rdr["pic"].ToString()),
                    Id = Convert.ToInt32(rdr["id"]),
                };
            }
            else throw new Exception("Хз, сбой");
        }



        static public void AddGroup(string groupName, string img, string about)
        {
            string sqlQuery = $"INSERT INTO groups (name, pic, about) VALUES ('{groupName}', '{img}', '{about}')";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
        }


        /// <summary>
        /// Получает ID через имя группы
        /// </summary>
        /// <param name="name">Имя группы</param>
        /// <returns>Группа(название)</returns>
        static public int GetGroupId(string name)
        {
            string sqlQuery = $"SELECT * FROM groups WHERE name = '{name}'";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
                return Convert.ToInt32(rdr["id"]);
            }
            else return (1);
        }

    }
}
