using BokningsApp.Models;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MongoDB.Bson;
using BokningsApp.Data;
using BokningsApp.ViewModels;

namespace BokningsApp.Views.User
{
    public partial class MyBookings : ContentPage
    {
        private readonly BookingHistoryViewModel _viewModel;

        public MyBookings()
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel();
            BindingContext = _viewModel;

            Task.Run(async () => await _viewModel.LoadUserBookings());
        }

        private async void OnRemoveBookingClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var booking = (Bookings)button.CommandParameter;

            bool isConfirmed = await DisplayAlert("Bekräfta",
                "Är du säker på att du vill ta bort bokningen?", "Ja", "Nej");

            if (isConfirmed)
            {
                _viewModel.UserBookings.Remove(booking);

                var result = await Data.DB.GetBookingCollection().DeleteOneAsync(b => b.Id == booking.Id); 

                if (result.DeletedCount > 0 )
                {
                    await DisplayAlert("Klart!", "Bokningen har tagits bort", "OK");
                }
                else
                {
                    await DisplayAlert("Fel!", "Bokningen gick ej att ta bort", "OK");
                }
                
            }
        }
    }
}


