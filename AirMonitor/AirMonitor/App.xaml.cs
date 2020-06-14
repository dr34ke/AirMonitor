using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AirMonitor.Views;
using AirMonitor.Models;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using SQLite;

namespace AirMonitor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            var resource = "AirMonitor.Models.config.json";
            Database.sQLiteConnection = new SQLiteConnection("");
            using (Stream stream = assembly.GetManifestResourceStream(resource))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                _Api api = JsonConvert.DeserializeObject<_Api>(result);
                Api.apiKey = api.apiKey;
                Api.url = api.url;
            }
            TabbedPage tabbed = new Tabbed();
            tabbed.Children.Add(new HomePage());
            tabbed.Children.Add(new SettingPage());
            MainPage = new NavigationPage(tabbed);
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
