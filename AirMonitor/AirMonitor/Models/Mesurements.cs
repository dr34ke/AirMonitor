using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Models
{
    class Mesurements
    {
        public int id { get; set; }
        public Current current { get; set; }
    }
    public class Current
    {
        public string fromDateTime { get; set; }
        public string tillDateTime { get; set; }
        public List<Values> values { get; set; }
        public List<Indexes> indexes { get; set; }
        public List<Standards> standards { get; set; }
     }
    public class Values
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class Indexes
    {
        public string name { get; set; }
        public string value { get; set; }
        public string level { get; set; }
        public string description { get; set; }
        public string advice { get; set; }
        public string color { get; set; }
    }
    public class Standards
    {
        public string name { get; set; }
        public string pollutant { get; set; }
        public string limit { get; set; }
        public string percent { get=>Math.Round(decimal.Parse(_percent)).ToString(); set { _percent = value; } }
        private string _percent { get; set; }
        public string averaging { get; set; }
    }
    class MesurementsEntity
    {
        public MesurementsEntity()
        {

        }
        [PrimaryKey]
        public int idMesurment { get; set; }
        public int idInstallation { get; set; }
    }
    public class CurrentEntity
    {
        public CurrentEntity()
        {

        }
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string fromDateTime { get; set; }
        public string tillDateTime { get; set; }
        public string values { get; set; }
        public string indexes { get; set; }
        public string standards { get; set; }
    }

}
