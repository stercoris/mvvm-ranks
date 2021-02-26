using Ranks.Models;
using System;
using System.Collections.Generic;


using System.Data.SQLite;

namespace Ranks.DataAccess
{
    class Groups
    {

        static private SQLiteConnection connection = DBConnection.connection;
        static private SQLiteCommand m_sqlCmd;
        static private SQLiteDataReader rdr;

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
                    About = rdr["about"].ToString(),
                };
                group.Users = users.FindAll((user) => user.GroupId == group.Id);

                groups.Add(group);
            }
            return (groups);
        }
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
        static public string GetBase64Image(int id)
        {

            string sqlQuery = $"SELECT pic FROM groups WHERE (id = {id})";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
            if (rdr.Read())
            {
                return (rdr["pic"].ToString());
            }
            else return null;
        }
        static public void AddOrUpdate(Group group)
        {
            string sqlQuery = $"REPLACE INTO groups(id,name,pic,about) " +
                $"VALUES('{group.Id}','{group.Name}', '{Services.ImageConverter.toBase64(group.hqImage)}', '{group.About}'); ";
            m_sqlCmd = new SQLiteCommand(sqlQuery, connection);
            rdr = m_sqlCmd.ExecuteReader();
        }

    }
}
