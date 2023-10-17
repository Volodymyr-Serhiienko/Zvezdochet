using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace WindowsFormsAppTest
{
    public class DBconnect
    {
        private static DBconnect _database;
        private SqliteConnection connection = new SqliteConnection("Data Source=AstroDB.db");
        private DBconnect()
        {

        }
        public static DBconnect getDataBase()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            if (_database == null)
            {
                _database = new DBconnect();
            }
            return _database;
        }
        public SqliteCommand DoSql(string sqlExpression)
        {
            connection.Open();
            return new SqliteCommand(sqlExpression, connection);
        }
        public void Close()
        {
            connection.Close();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
        }
    }
}
