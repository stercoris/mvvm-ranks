using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.DataBase
{
    static partial class Users
    {
        static private SQLiteConnection connection = DBConnection.connection;
        static private SQLiteCommand m_sqlCmd;
        static private SQLiteDataReader rdr;
        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns>Лист(номер,пользователь)</returns>
        static public List<User> GetAll()
        {
            string sqlQuery = $"SELECT * FROM Users";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            List<User> users = new List<User> { };
            while (rdr.Read())
            {
                User user = new User();
                user.id = Convert.ToInt32(rdr["id"]);
                user.name = rdr["name"].ToString();
                user.sec_name = rdr["sec_name"].ToString();
                user.user_group = Convert.ToInt32(rdr["user_group"]);
                user.rank = Convert.ToInt32(rdr["rank"]);
                user.is_admin = Convert.ToBoolean(rdr["is_admin"]);
                user.pass = rdr["pass"].ToString();
                user.pic = rdr["pic"].ToString();
                user.about = rdr["about"].ToString();
                users.Add(user);
            }
            return (users);
        }
        /// <summary>
        /// Получает пользователя
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns></returns>
        static public global::Ranks.User GetById(int id)
        {

            string sqlQuery = $"SELECT * FROM Users WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
                global::Ranks.User user = new User
                {
                    id = Convert.ToInt32(rdr["id"]),
                    name = rdr["name"].ToString(),
                    sec_name = rdr["sec_name"].ToString(),
                    user_group = Convert.ToInt32(rdr["user_group"]),
                    rank = Convert.ToInt32(rdr["rank"]),
                    is_admin = Convert.ToBoolean(rdr["is_admin"]),
                    pass = rdr["pass"].ToString(),
                    pic = rdr["pic"].ToString(),
                    about = rdr["about"].ToString(),
                };
                return (user);
            }
            else return null;
        }
        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        static public void Add(User user)
        {
            string sqlQuery = $"INSERT INTO Users (name,sec_name,user_group,rank,is_admin,pass,pic,about) VALUES ('{user.name}','{user.sec_name}','{user.user_group}',{user.rank},{user.is_admin},'{user.pass}','{user.pic}','{user.about}')";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// Обновляет пользователя
        /// </summary>
        static public void Update(User user)
        {
            string sqlQuery = $"UPDATE Users SET name = '{user.name}',sec_name = '{user.sec_name}',user_group = '{user.user_group}',rank = {user.rank},is_admin = {user.is_admin},pass = '{user.pass}',pic = '{user.pic}',about = '{user.about}' WHERE id = {user.id}";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id">ID пользователя</param>
        static public void DeleteById(int id)
        {
            string sqlQuery = $"DELETE FROM Users WHERE (id={id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            Console.WriteLine("Пользователь удален !о! !н!е!т!");
        }
    }
}
