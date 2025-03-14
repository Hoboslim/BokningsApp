using BokningsApp.Models;
using BokningsApp.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BokningsApp.User;

public partial class PickRoom : ContentPage
{
	private BookingViewModel _ViewModel;
    private WeatherViewModel WeatherWM { get; }
    public PickRoom(string selectedDate)
	{
		InitializeComponent();
		_ViewModel = new BookingViewModel(selectedDate);
		BindingContext = _ViewModel;
        WeatherWM = new WeatherViewModel();
        _ = GetWeather();
    }
	private async Task GetWeather()
    {
        await WeatherWM.GetWeatherAsync(59.3293, 18.0686);
    }

    private async void OnBookClicked(object sender, EventArgs e)
    {
		if (_ViewModel.SelectedRoom != null && _ViewModel.StartTime != null && _ViewModel.EndTime !=null)
		{
            DateTime selectedDate = DateTime.Parse(_ViewModel.SelectedDate);
            DateTime startDateTime = selectedDate.Date + _ViewModel.StartTime;
            DateTime endDateTime = selectedDate.Date + _ViewModel.EndTime;
			startDateTime = DateTime.SpecifyKind(startDateTime, DateTimeKind.Unspecified);
            endDateTime = DateTime.SpecifyKind(endDateTime, DateTimeKind.Unspecified);

            var userIdString = await SecureStorage.GetAsync("user_id");
			var userEmail = await SecureStorage.GetAsync("user_email");
            

            if (string.IsNullOrEmpty(userIdString))
			{
				await DisplayAlert("Error", "Ingen användare inloggad", "OK");
				return;
			}

            var userId = new ObjectId(userIdString);
            var roomId = _ViewModel.SelectedRoom.Id;

            var existingBooking = await Data.DB.GetBookingCollection()
				.Find(b => b.RoomId == roomId &&
				b.StartTime < endDateTime &&
				b.EndTime > startDateTime).FirstOrDefaultAsync();

			if (existingBooking != null)
			{
				await DisplayAlert("Bokning fel", "Rummet är redan bokat för denna tid", "OK");
			}

			var booking = new Bookings
			{
				Id = ObjectId.GenerateNewId(),
				RoomName = _ViewModel.SelectedRoom.RoomName,
                Email = userEmail,
                UserId = userId,
				RoomId = _ViewModel.SelectedRoom.Id,
				StartTime = startDateTime,
				EndTime = endDateTime,
				Participants = new List<ObjectId> { userId }
			};
            var bookingsCollection = Data.DB.GetBookingCollection();
            await bookingsCollection.InsertOneAsync(booking);

			await DisplayAlert("Bokning lyckades!", "Rummet har bokats från den valda tiden","OK");

        }

        else
        {
			await DisplayAlert("Felaktig inmatning", "Välj ett rum och en tid", "OK");
		}
    }
}