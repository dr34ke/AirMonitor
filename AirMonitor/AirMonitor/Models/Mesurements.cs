using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic; 
using System.Text;
using RestSharp;

namespace AirMonitor.Models
{
    class Mesurements
    {
        public Mesurements(string id)
        {
            Mesurements mess = GetMesurements();
            if(mess.id != 0)
            {
                this.id = mess.id;
                this.current = mess.current;
            }
            else
            {
                RestClient client = new RestClient(@Api.url);
                RestRequest request = new RestRequest("/measurements/installation", Method.GET);
                request.AddHeader("apikey", Api.apiKey);
                request.AddParameter("installationId", id);
                request.AddHeader("Accept-Language", "pl");
                var response = client.Execute(request);
                Mesurements _mess = JsonConvert.DeserializeObject<Mesurements>(response.Content);
                this.current = _mess.current;
                this.id = _mess.id;
                new MesurementsEntity(this, id);
            }
        }
        public Mesurements()
        {

        }
        public Mesurements GetMesurements()
        {
            try
            {
                List<MesurementsEntity> mesurements = Database.sQLiteConnection.Table<MesurementsEntity>().ToList();
                foreach (MesurementsEntity mes in mesurements)
                {
                    Mesurements mess = new Mesurements(mes);
                    DateTime a = DateTime.Parse(mess.current.tillDateTime);
                    if (a < DateTime.Now.ToUniversalTime())
                        return mess;
                }
                return new Mesurements();
            }
            catch
            {
                return new Mesurements();
            }
        }
        public Mesurements(MesurementsEntity mesurements)
        {
            this.id = mesurements.idMesurment;
            this.current= new Current(mesurements.idMesurment.ToString());
        }
        public int id { get; set; }
        public Current current { get; set; }
    }
    public class Current
    {
        public Current(string id)
        {
            CurrentEntity cur = Database.sQLiteConnection.Get<CurrentEntity>(id);
            this.values = JsonConvert.DeserializeObject<List<Values>>(cur.values);
            this.indexes = JsonConvert.DeserializeObject<List<Indexes>>(cur.indexes);
            this.standards = JsonConvert.DeserializeObject<List<Standards>>(cur.standards);
            this.tillDateTime = cur.tillDateTime;
            this.fromDateTime = cur.fromDateTime;
        }
        public Current()
        {

        }
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
        public MesurementsEntity(Mesurements mesurements, string idInstllation)
        {
            CurrentEntity current = new CurrentEntity(mesurements.current);
            idMesurment = current.id;
            this.idInstallation = Int32.Parse(idInstllation);
            Database.Insert<MesurementsEntity>(this);
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
        public CurrentEntity(Current current)
        {
            this.fromDateTime = current.fromDateTime;
            this.tillDateTime = current.tillDateTime;
            this.values = JsonConvert.SerializeObject(current.values);
            this.indexes = JsonConvert.SerializeObject(current.indexes);
            this.standards = JsonConvert.SerializeObject(current.standards);
            Database.Insert<CurrentEntity>(this);
        }
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string fromDateTime { get; set; }
        public string tillDateTime { get; set; }
        public string values { get; set; }
        public string indexes { get; set; }
        public string standards { get; set; }
    }

}
