using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Models
{
    class Installation
    {
        public string id { get; set; }
        public Location location { get; set; }
        public Address address { get; set; }
        public string elevation { get; set; }
        public string airly { get; set; }
        public Sponsor sponsor { get; set; }
    }
    class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
    public class Address
    {
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string displayAddress1 { get; set; }
        public string displayAddress2 { get; set; }
    }
    public class Sponsor
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string logo { get; set; }
        public string link { get; set; }
        public string displayName { get; set; }
    }
    class InstallationEntity
    {
        public InstallationEntity(Installation installation)
        {
            this.location = JsonConvert.SerializeObject(installation.location);
            this.address = JsonConvert.SerializeObject(installation);
            this.elevation = JsonConvert.SerializeObject(installation);
            this.airly = installation.airly;
            this.sponsor = JsonConvert.SerializeObject(installation);
        }
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string location { get; set; }
        public string address { get; set; }
        public string elevation { get; set; }
        public string airly { get; set; }
        public string sponsor { get; set; }
    }
}
