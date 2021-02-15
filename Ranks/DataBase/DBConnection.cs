using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranks.DataBase
{
    static partial class DBConnection
    {
        private static SQLiteConnection _connection = null;
        static public SQLiteConnection connection
        {
            get
            {
                if (_connection == null) connection = Connect("users.db");
                return _connection;

            }
            set { _connection = value; }
        }

        /// <summary>
        /// Открытие соединения с DB
        /// </summary>
        /// <param name="dbname">имя бызы данных</param>
        static private SQLiteConnection Connect(string dbname)
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={dbname};Version=3;");
            //m_sqlCmd = new SQLiteCommand();
            connection.Open();
            //m_sqlCmd.Connection = m_dbConn;
            return (connection);
        }

    }
}
