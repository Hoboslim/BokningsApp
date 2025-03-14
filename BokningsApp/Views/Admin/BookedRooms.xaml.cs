using BokningsApp.Models;
using BokningsApp.ViewModels;
using MongoDB.Driver;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BokningsApp.Admin
{
    public partial class BookedRooms : ContentPage
    {
        private readonly BookingHistoryViewModel _viewModel;

        public BookedRooms()
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel();
            BindingContext = _viewModel;
            LoadRoomsAsync();
        }

        private async void LoadRoomsAsync()
        {
            await _viewModel.LoadBookedRooms();
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

                var result = await Data.DB.GetBookingCollection().DeleteOneAsync
                    (Builders<Bookings>.Filter.Eq(b => b.Id, booking.Id));

                if (result.DeletedCount > 0)
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
