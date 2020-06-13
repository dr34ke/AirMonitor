using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Models
{
    public class _Api
    {
        public string apiKey { get; set; }
        public string url { get; set; }
    }
    public static class Api
    {
        public static string apiKey { get; set; }
        public static string url { get; set; }
    }
    public static class Database
    {
        public static SQLiteConnection sQLiteConnection { get; set; }
    }
}

