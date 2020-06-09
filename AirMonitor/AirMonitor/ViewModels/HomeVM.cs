using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AirMonitor.Views;

namespace AirMonitor.ViewModels
{
    class HomeVM
    {
        private INavigation naviation;
        public HomeVM(INavigation nav)
        {
            this.naviation = nav;
            this.openDetails = new Command(goToDetails);
        }
        private ICommand _openDetails;
        public ICommand openDetails {
            get => _openDetails; 
            set => _openDetails=value; 
        }
        private void goToDetails()
        {
            this.naviation.PushAsync(new DetailsPage());
        }

    }
}
