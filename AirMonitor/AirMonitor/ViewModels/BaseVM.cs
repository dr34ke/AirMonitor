using AirMonitor.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;


namespace AirMonitor.ViewModels
{
    class BaseVM:INotifyPropertyChanged
    {


        public ObservableCollection<Installation> installations { get; set; }
        public Mesurements mesurements
        {
            get => _mesurements; set
            {
                _mesurements = value;
                OnPropertyChanged(nameof(_mesurements));
            }
        }
        private Mesurements _mesurements { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public double latitude
        {
            get => _latitude; set
            {
                _latitude = value;
                OnPropertyChanged(nameof(_latitude));
            }
        }
        private double _latitude { get; set; }
        public double longitude
        {
            get => _longitude; set
            {
                _longitude = value;
                OnPropertyChanged(nameof(_longitude));
            }
        }
        private double _longitude { get; set; }
        public void GetLocation()
        {
            try
            {
                var location = Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    this.latitude = location.Result.Latitude;
                    this.longitude = location.Result.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                var x = 1;
            }
        }
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void getNearest()
        {
            GetLocation();
            RestClient client = new RestClient(@Api.url);
            RestRequest request = new RestRequest("/installations/nearest", Method.GET);
            request.AddHeader("apikey", Api.apiKey);
            request.AddParameter("lat", latitude);
            request.AddParameter("lng", longitude);
            request.AddParameter("maxDistanceKM", "30");
            var response = client.Execute(request);
            this.installations = JsonConvert.DeserializeObject<ObservableCollection<Installation>>(response.Content);
            InsertInstallations(this.installations);
        }
        public void InsertInstallations(ObservableCollection<Installation> installations)
        {
            foreach(Installation installation in installations)
            {
                Database.Insert<InstallationEntity>(new InstallationEntity(installation));
            }
        }
        public void getMesurements(string id)
        {
            GetLocation();
            this.mesurements = new Mesurements(id);
        }
        public void InsertMesurements(Mesurements mesurements, string idInstallation)
        {
            Database.Insert<MesurementsEntity>(new MesurementsEntity(mesurements, idInstallation));
        }
        
    }
}
