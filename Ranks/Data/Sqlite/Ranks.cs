using Ranks.Models;
using System;
using System.Collections.Generic;


using System.Data.SQLite;

namespace Ranks.DataServices
{
    class Ranks
    {
        static private SQLiteConnection connection = DBConnection.connection;
        static private SQLiteCommand m_sqlCmd;
        static private SQLiteDataReader rdr;

        /// <summary>
        /// Добавляет к рангу пользователя значение
        /// </summary>
        /// <param name="id"> ID пользователя</param>
        /// <param name="rank_diff">сколько добавлять</param>
        static public void AddToRank(int id, int rank_diff)
        {
            string sqlQuery = $"UPDATE Users SET rank = rank + {rank_diff} WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
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
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
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
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            Console.WriteLine("Пользователь изменен");
        }
        /// <summary>
        /// Полностью обновляет ранги
        /// </summary>
        /// <param name="rankname">Название ранга</param>
        static public void UpdateAll(List<string> ranks)
        {
            string sqlQuery = $"DELETE FROM ranks";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            foreach (string rank in ranks)
            {
                sqlQuery = $"INSERT INTO ranks (name) VALUES ('{rank}')";
                m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
                rdr = m_sqlCmd.ExecuteReader();
            }
        }
        /// <summary>
        /// Изменяет название ранга
        /// </summary>
        /// <param name="rankname"> Новое название </param>
        /// <param name="id">ID ранга</param>
        static public void ChangeName(string rankname, int id)
        {
            string sqlQuery = $"UPDATE ranks SET name = '{rankname}' WHERE (rank = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
        }
        /// <summary>
        ///  Получает все ранги
        /// </summary>
        /// <returns> Массив рангов </returns>
        static public List<Rank> GetAll()
        {
            string sqlQuery = $"SELECT * FROM ranks";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            List<Rank> ranks = new List<Rank> { };
            while (rdr.Read())
            {
                ranks.Add(new Rank
                {
                    Id = Convert.ToInt32(rdr["rank"]),
                    Name = rdr["name"].ToString(),
                });
            }
            return (ranks);
        }
        /// <summary>
        ///  Получает ранг через ID ранга
        /// </summary>
        /// <param name="rankId">ID ранга</param>
        /// <returns>Ранг(название)</returns>
        static public Rank Get(int rankId)
        {
            List<Rank> ranks = GetAll();
            if (rankId < 0) return (ranks[0]);
            else if (rankId >= ranks.Count) return (ranks[ranks.Count - 1]);
            else return (ranks[rankId]);
        }
    }
}
