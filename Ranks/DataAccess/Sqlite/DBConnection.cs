using System.Data.SQLite;

namespace Ranks.DataAccess
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
        static private SQLiteConnection Connect(string dbname)
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={dbname};Version=3;");
            connection.Open();
            return (connection);
        }

    }
}
