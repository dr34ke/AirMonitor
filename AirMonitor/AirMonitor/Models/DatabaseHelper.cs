using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Models
{
    class DatabaseHelper
    {
        public DatabaseHelper(string path)
        {
            this.sQLiteConnection = new SQLiteConnection(path);
        }
        public DatabaseHelper(SQLiteConnection conn)
        {
            this.sQLiteConnection = conn;
        }
        public SQLiteConnection sQLiteConnection { get; set; }
    }
    public static class Database
    {
        public static SQLiteConnection sQLiteConnection { get; set; }
        public static void Insert<T>(T data)
        {
            sQLiteConnection.CreateTable<T>();
            sQLiteConnection.Insert(data);
        }
    }
}
