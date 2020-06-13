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
        public SQLiteConnection sQLiteConnection { get; set; }
        
    }
}
