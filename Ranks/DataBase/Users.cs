using Ranks.Model;
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
                User user = new User
                {
                    Id = Convert.ToInt32(rdr["id"]),
                    Name = rdr["name"].ToString(),
                    SecondName = rdr["sec_name"].ToString(),
                    Group = Groups.GroupById(Convert.ToInt32(rdr["user_group"])),
                    Rank = Ranks.Get(Convert.ToInt32(rdr["rank"])),
                    IsAdmin = Convert.ToBoolean(rdr["is_admin"]),
                    Password = rdr["pass"].ToString(),
                    Picture = Services.ImageConverter.toBitmapImage(rdr["pic"].ToString()),
                    About = rdr["about"].ToString(),
                };
                users.Add(user);
            }
            return (users);
        }
        /// <summary>
        /// Получает пользователя
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns></returns>
        static public User GetById(int id)
        {

            string sqlQuery = $"SELECT * FROM Users WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
               User user = new User
                {
                    Id = Convert.ToInt32(rdr["id"]),
                    Name = rdr["name"].ToString(),
                    SecondName = rdr["sec_name"].ToString(),
                    Group = Groups.GroupById(Convert.ToInt32(rdr["user_group"])),
                    Rank = Ranks.Get(Convert.ToInt32(rdr["rank"])),
                    IsAdmin = Convert.ToBoolean(rdr["is_admin"]),
                    Password = rdr["pass"].ToString(),
                    Picture = Services.ImageConverter.toBitmapImage(rdr["pic"].ToString()),
                    About = rdr["about"].ToString(),
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
            string sqlQuery = $"INSERT INTO Users (name,sec_name,user_group,rank,is_admin,pass,pic,about) VALUES ('{user.Name}','{user.SecondName}','{user.Group}',{user.Rank},{user.IsAdmin},'{user.Password}','{user.Picture}','{user.About}')";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// Обновляет пользователя
        /// </summary>
        static public void Update(User user)
        {
            string sqlQuery = $"UPDATE Users SET name = '{user.Name}',sec_name = '{user.SecondName}',user_group = '{user.Group}',rank = {user.Rank},is_admin = {user.IsAdmin},pass = '{user.Password}',pic = '{user.Picture}',about = '{user.About}' WHERE id = {user.Id}";
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
