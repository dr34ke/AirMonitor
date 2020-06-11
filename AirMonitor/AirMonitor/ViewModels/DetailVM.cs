using AirMonitor.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AirMonitor.ViewModels
{
    class DetailVM : BaseVM
    {
        private ICommand _details { get; set; }
        public ICommand details { 
            get => _details; 
            set => _details=value; 
        }
        public int CAQI { get=>_CAQI; set{
                _CAQI = value;
                OnPropertyChanged(nameof(_CAQI));
            } }
        private int _CAQI { get; set; }
        public int pm25
        {
            get => _pm25; set
            {
                _pm25 = value;
                OnPropertyChanged(nameof(_pm25));
            }
        }
        private int _pm25 { get; set; }
        public int pm10
        {
            get => _pm10; set
            {
                _pm10 = value;
                OnPropertyChanged(nameof(_pm10));
            }
        }
        private int _pm10 { get; set; }
        public int humidity
        {
            get => _humidity; set
            {
                _humidity = value;
                OnPropertyChanged(nameof(_humidity));
            }
        }
        private int _humidity { get; set; }
        public int hpa
        {
            get => _hpa; set
            {
                _hpa = value;
                OnPropertyChanged(nameof(_hpa));
            }
        }
        private int _hpa { get; set; }
        private ContentPage page { get; set; }
        public DetailVM(ContentPage navigationPage, string id)
        {
            this.details = new Command(Display);
            getMesurements(id);
            this.page = navigationPage;
        }
        public void Display()
        {
            this.page.DisplayAlert("CAQI", "An air quality index (AQI) is used by government agencies[1] to communicate to the public how polluted the air currently is or how polluted it is forecast to become.[2][3] Public health risks increase as the AQI rises. Different countries have their own air quality indices, corresponding to different national air quality standards. Some of these are the Air Quality Health Index (Canada), the Air Pollution Index (Malaysia), and the Pollutant Standards Index (Singapore). Smog in Shanghai, December 1993—an example of air conditions typically rated as unhealthy An annotated satellite photo showing smoke from wildfires in Greece, giving rise to an elevated AQI downwind", "OK");
        }
    }
}
