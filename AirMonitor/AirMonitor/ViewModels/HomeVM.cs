using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using AirMonitor.Views;
using AirMonitor.Models;
using System.Threading.Tasks;

namespace AirMonitor.ViewModels
{
    class HomeVM :BaseVM
    {
        private INavigation naviation;
        public HomeVM(INavigation nav)
        {
            getNearest();
            this.naviation = nav;
        }
        public async void Display(object sender, ItemTappedEventArgs e)
        {
            Installation installation = e.Item as Installation;
            await naviation.PushAsync(new DetailsPage(installation.id));
        }
    }
}
