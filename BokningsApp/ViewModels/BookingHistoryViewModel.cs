using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BokningsApp.Models;
using BokningsApp.Data;
using MongoDB.Driver;
using MongoDB.Bson; 

namespace BokningsApp.ViewModels
{
    public class BookingHistoryViewModel
    {
        public ObservableCollection<Bookings> OldBookings { get; set; } = new();
        public ObservableCollection<Rooms> BookedRooms { get; set; } = new();
        public ObservableCollection<Bookings> UserBookings { get; set; } = new();
        public BookingHistoryViewModel() { }

        TimeZoneInfo swedenTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

        public async Task LoadOldBookings()
        {
            
            var oldBookings = await DB.GetBookingCollection()
                .Find(b => b.EndTime < System.DateTime.UtcNow)
                .ToListAsync();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                UserBookings.Clear();
                foreach (var booking in oldBookings)
                {
                    booking.StartTime = TimeZoneInfo.ConvertTimeFromUtc(booking.StartTime, swedenTimeZone);
                    booking.EndTime = TimeZoneInfo.ConvertTimeFromUtc(booking.EndTime, swedenTimeZone);

                    UserBookings.Add(booking);
                }
            });
        }

        public async Task LoadBookedRooms()
        {
     
              var bookings = await DB.GetBookingCollection()
                .Find(b => b.EndTime >= System.DateTime.UtcNow)
                .ToListAsync();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                UserBookings.Clear();
                foreach (var booking in bookings)
                {
                    booking.StartTime = TimeZoneInfo.ConvertTimeFromUtc(booking.StartTime, swedenTimeZone);
                    booking.EndTime = TimeZoneInfo.ConvertTimeFromUtc(booking.EndTime, swedenTimeZone);

                    UserBookings.Add(booking);
                }
            });
        }

        public async Task LoadUserBookings()
        {
            var userIdString = await SecureStorage.GetAsync("user_id");
            if (string.IsNullOrEmpty(userIdString))
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Ingen användare inloggad", "OK");
                return;
            }

            var loggedInUserId = new ObjectId(userIdString);

            var userBookings = await Data.DB.GetBookingCollection()
                .Find(b => b.UserId == loggedInUserId && b.EndTime >= DateTime.UtcNow)
                .ToListAsync();

            
            MainThread.BeginInvokeOnMainThread(() =>
            {
                UserBookings.Clear();
                foreach (var booking in userBookings)
                {
                    booking.StartTime = TimeZoneInfo.ConvertTimeFromUtc(booking.StartTime, swedenTimeZone);
                    booking.EndTime = TimeZoneInfo.ConvertTimeFromUtc(booking.EndTime, swedenTimeZone);

                    UserBookings.Add(booking);
                }
            });
        }
    }
}
