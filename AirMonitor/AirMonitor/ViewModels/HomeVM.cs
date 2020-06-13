using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using AirMonitor.Views;
using AirMonitor.Models;
using AirMonitor.Converters;
using System.Threading.Tasks;


namespace AirMonitor.ViewModels
{
    class HomeVM :BaseVM
    {
        public string isVisibleAI { get=>_isVisibleAI; set{
                _isVisibleAI = value;
                OnPropertyChanged(nameof(_isVisibleAI));
            } }
        private string _isVisibleAI { get; set; }
        private INavigation naviation;
        public HomeVM(INavigation nav)
        {
            getNearest();
            this.naviation = nav;
        }
    }
}
