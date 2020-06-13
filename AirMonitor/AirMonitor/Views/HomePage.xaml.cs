using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AirMonitor.ViewModels;
using AirMonitor.Models;

namespace AirMonitor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        
        public HomePage()
        {
            BindingContext = new HomeVM(Navigation);
            InitializeComponent();
        }
        public async void Display(object sender, ItemTappedEventArgs e)
        {
            Installation installation = e.Item as Installation;
            await Navigation.PushAsync(new DetailsPage(installation.id));

        }
    }
}