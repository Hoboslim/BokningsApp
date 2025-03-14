using BokningsApp.Models;
using BokningsApp.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace BokningsApp.User;

public partial class PickRoom : ContentPage
{
    private CombinedViewModel _viewModel;

    public PickRoom(string selectedDate)
    {
        InitializeComponent();
        _viewModel = new CombinedViewModel(selectedDate);
        BindingContext = _viewModel;

        _ = InitializeData();
    }

    private async Task InitializeData()
    {
        await GetWeather();
        await _viewModel.BookingVM.LoadRoomTypes(); // ? Laddar rumstyper direkt när sidan öppnas
    }

    private async Task GetWeather()
    {
        double stockholmLatitude = 59.3293;
        double stockholmLongitude = 18.0686;
        await _viewModel.WeatherVM.GetWeatherAsync(stockholmLatitude, stockholmLongitude);
    }

    private async void OnBookClicked(object sender, EventArgs e)
    {
        if (_viewModel.BookingVM.SelectedRoom != null
            && _viewModel.BookingVM.StartTime != null
            && _viewModel.BookingVM.EndTime != null)
        {
            DateTime selectedDate = DateTime.Parse(_viewModel.BookingVM.SelectedDate);
            DateTime startDateTime = selectedDate.Date + _viewModel.BookingVM.StartTime;
            DateTime endDateTime = selectedDate.Date + _viewModel.BookingVM.EndTime;

            startDateTime = DateTime.SpecifyKind(startDateTime, DateTimeKind.Unspecified);
            endDateTime = DateTime.SpecifyKind(endDateTime, DateTimeKind.Unspecified);

			var userIdString = await SecureStorage.GetAsync("user_id");
			var userEmail = await SecureStorage.GetAsync("user_email");

			TimeSpan minTime = new TimeSpan(7, 0, 0);
			TimeSpan maxTime = new TimeSpan(17, 0, 0);

			if (selectedDate.Date < DateTime.Today)
			{
				await DisplayAlert("Felaktigt datum", "Du kan inte boka för ett datum som passerat", "OK");
				return;
			}

			if (startDateTime.TimeOfDay < minTime || startDateTime.TimeOfDay > maxTime)
			{
				await DisplayAlert("Felaktig tid", "Välj en tid mellan 07:00 och 17:00", "OK");
				return;
			}

			if (endDateTime.TimeOfDay < minTime || startDateTime.TimeOfDay > maxTime)
			{
				await DisplayAlert("Felaktid tid", "Välj en tid mellan 07:00 och 17:00", "OK");
				return;
			}


			if (string.IsNullOrEmpty(userIdString))
			{
				await DisplayAlert("Error", "Ingen användare inloggad", "OK");
				return;
			}

            var userId = new ObjectId(userIdString);
            var roomId = _viewModel.BookingVM.SelectedRoom.Id;

            var existingBooking = await Data.DB.GetBookingCollection()
                .Find(b => b.RoomId == roomId &&
                        b.StartTime < endDateTime &&
                        b.EndTime > startDateTime)
                .FirstOrDefaultAsync();

            if (existingBooking != null)
            {
                await DisplayAlert("Bokning fel", "Rummet är redan bokat för denna tid", "OK");
                return;
            }

            var booking = new Bookings
            {
                Id = ObjectId.GenerateNewId(),
                RoomName = _viewModel.BookingVM.SelectedRoom.RoomName,
                Email = userEmail,
                UserId = userId,
                RoomId = _viewModel.BookingVM.SelectedRoom.Id,
                StartTime = startDateTime,
                EndTime = endDateTime,
                Participants = new List<ObjectId> { userId }
            };

            var bookingsCollection = Data.DB.GetBookingCollection();
            await bookingsCollection.InsertOneAsync(booking);

            await DisplayAlert("Bokning lyckades!", "Rummet har bokats från den valda tiden", "OK");
        }
        else
        {
            await DisplayAlert("Felaktig inmatning", "Välj ett rum och en tid", "OK");
        }
    }
}
