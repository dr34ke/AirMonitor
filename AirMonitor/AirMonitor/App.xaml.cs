using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AirMonitor.Views;

namespace AirMonitor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
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
