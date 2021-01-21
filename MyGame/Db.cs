using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ranks
{
    static class Db
    {
        static private SQLiteConnection m_dbConn;
        static private SQLiteCommand m_sqlCmd;
        static private SQLiteDataReader rdr;
        /// <summary>
        /// Открытие соединения с DB
        /// </summary>
        /// <param name="dbname">имя бызы данных</param>
        static public void OpenConnect(string dbname)
        {
            Console.WriteLine($"Плодключение к {dbname}");
            m_dbConn = new SQLiteConnection($"Data Source={dbname};Version=3;");
            m_sqlCmd = new SQLiteCommand();
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
        }
        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns>Лист(номер,пользователь)</returns>
        static public Dictionary<int, User> GetAllUsers()
        {
            string sqlQuery = $"SELECT * FROM Users";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            Dictionary<int, User> users = new Dictionary<int, User> { };
            while (rdr.Read())
            {
                Console.WriteLine(rdr.FieldCount);
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
                users.Add(Convert.ToInt32(rdr.GetValue(0)), user);
            }
            return (users);
        }
        /// <summary>
        /// Получает пользователя
        /// </summary>
        /// <param name="id">ID пользователя</param>
        /// <returns></returns>
        static public User GetUser(int id)
        {

            string sqlQuery = $"SELECT * FROM Users WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
                User user = new User
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
        static public void AddUser(User user)
        {
            string sqlQuery = $"INSERT INTO Users (name,sec_name,user_group,rank,is_admin,pass,pic,about) VALUES ('{user.name}','{user.sec_name}','{user.user_group}',{user.rank},{user.is_admin},'{user.pass}','{user.pic}','{user.about}')";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// Обновляет пользователя
        /// </summary>
        static public void UpdateUser(User user)
        {
            string sqlQuery = $"UPDATE Users SET name = '{user.name}',sec_name = '{user.sec_name}',user_group = '{user.user_group}',rank = {user.rank},is_admin = {user.is_admin},pass = '{user.pass}',pic = '{user.pic}',about = '{user.about}' WHERE id = {user.id}";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
        }
        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id">ID пользователя</param>
        static public void DeleteUser(int id)
        {
            string sqlQuery = $"DELETE FROM Users WHERE (id={id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            Console.WriteLine("Пользователь удален !о! !н!е!т!");
        }
        /// <summary>
        /// Добавляет к рангу пользователя значение
        /// </summary>
        /// <param name="id"> ID пользователя</param>
        /// <param name="rank_diff">сколько добавлять</param>
        static public void AddToRank(int id, int rank_diff)
        {
            string sqlQuery = $"UPDATE Users SET rank = rank + {rank_diff} WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            Console.WriteLine("Пользователь изменен");
        }
        /// <summary>
        /// Отнимает от ранга пользователя значение
        /// </summary>
        /// <param name="id"> ID пользователя</param>
        /// <param name="rank_diff">сколько отнимать</param>
        static public void RemoveFromRank(int id, int rank_diff)
        {
            string sqlQuery = $"UPDATE Users SET rank = rank - {rank_diff} WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            Console.WriteLine("Пользователь изменен");
        }
        /// <summary>
        /// Устанавливает  ранг пользователя
        /// </summary>
        /// <param name="id"> ID пользователя</param>
        /// <param name="rank">Ранг</param>
        static public void SetUserRank(int id, int rank)
        {
            string sqlQuery = $"UPDATE Users SET rank = {rank} WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            Console.WriteLine("Пользователь изменен");
        }
        /// <summary>
        /// Полностью обновляет ранги
        /// </summary>
        /// <param name="rankname">Название ранга</param>
        static public void UpdateRanks(List<string> ranks)
        {
            string sqlQuery = $"DELETE FROM ranks";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            foreach (string rank in ranks)
            {
                sqlQuery = $"INSERT INTO ranks (name) VALUES ('{rank}')";
                m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
                rdr = m_sqlCmd.ExecuteReader();
            }
        }
        /// <summary>
        /// Изменяет название ранга
        /// </summary>
        /// <param name="rankname"> Новое название </param>
        /// <param name="id">ID ранга</param>
        static public void ChangeRankName(string rankname, int id)
        {
            string sqlQuery = $"UPDATE ranks SET name = '{rankname}' WHERE (rank = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
        }
        /// <summary>
        ///  Получает все ранги
        /// </summary>
        /// <returns> Массив рангов </returns>
        static public List<string> GetRanks()
        {
            string sqlQuery = $"SELECT * FROM ranks";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            List<string> ranks = new List<string> { };
            while (rdr.Read())
            {
                ranks.Add(rdr["name"].ToString());
            }
            return (ranks);
        }
        /// <summary>
        ///  Получает ранг через ID ранга
        /// </summary>
        /// <param name="rankId">ID ранга</param>
        /// <returns>Ранг(название)</returns>
        static public string GetRank(int rankId)
        {
            List<string> ranks = GetRanks();
            if (rankId < 0) return (ranks[0]);
            else if (rankId >= ranks.Count) return (ranks[ranks.Count - 1]);
            else return (ranks[rankId]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public List<string> GetGroups()
        {
            string sqlQuery = $"SELECT * FROM groups";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            List<string> groups = new List<string> { };
            while (rdr.Read())
            {
                groups.Add(rdr["name"].ToString());
            }
            return (groups);
        }
        /// <summary>
        /// Получает имя группы через ID
        /// </summary>
        /// <param name="groupId">ID группы</param>
        /// <returns>Группа(название)</returns>
        static public string GroupById(int groupId)
        {
            string sqlQuery = $"SELECT * FROM groups WHERE id = {groupId}";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
                return rdr["name"].ToString();
            }
            else return ("Хз, сбой");
        }

        /// <summary>
        /// Получает ID через имя группы
        /// </summary>
        /// <param name="name">Имя группы</param>
        /// <returns>Группа(название)</returns>
        static public int GetGroupId(string name)
        {
            string sqlQuery = $"SELECT * FROM groups WHERE name = '{name}'";
            m_sqlCmd = new SQLiteCommand(sqlQuery, m_dbConn);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
                return Convert.ToInt32(rdr["id"]);
            }
            else return (1);
        }
    }
}
