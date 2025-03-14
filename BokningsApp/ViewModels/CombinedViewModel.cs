using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.ViewModels
{
    public class CombinedViewModel
    {
        public BookingViewModel BookingVM { get; set; }
        public WeatherViewModel WeatherVM { get; set; }

        public CombinedViewModel(string selectedDate)
        {
            BookingVM = new BookingViewModel(selectedDate);
            WeatherVM = new WeatherViewModel();
        }
    }

}
